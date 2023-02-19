using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using DbConnector;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SkinnerProjectManager
{
    public partial class Home : MetroForm
    {
        DbUtils db;
        string selectedId = null;
        string payloadFile;
        bool waitingCreation;
        public Home()
        {
            InitializeComponent();

            waitingCreation = false;
            try
            {
                db = new DbUtils("SELECT * from artists");
                dataGridView1.DataSource = db.artistData;
            }
            catch (Exception e)
            {
                Console.WriteLine("error catched" + e.Message);
            }
        }

        private void navigationTab_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
        }

        private void radLabel10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            selectedId = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void gridview_1Click(object sender, DataGridViewCellEventArgs e)
        {
            waitingCreation = false;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            selectedId = row.Cells[0].Value.ToString();
            editName.Text = row.Cells[1].Value.ToString();
            editDbSecond.Text = row.Cells[2].Value.ToString();
            editDbThird.Text = row.Cells[3].Value.ToString();
            editDbFourth.Text = row.Cells[4].Value.ToString();
            EditContact.Text = row.Cells[5].Value.ToString();
            payloadFile = row.Cells[8].Value.ToString();
            string tagName = db.getTagName(selectedId);
            if (!string.IsNullOrEmpty(tagName))
            {
                editTag.Text = tagName;
            } else
            {
                editTag.Text = "";
                editTag.NullText = "Insérer votre tag";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string checkTagExist(string tag)
        {
            string query = "SELECT tag_id, nom FROM tags WHERE nom = @tag";
            string result = (db.ValueExistInDb(tag, query));

            return result;
        }

        private async void radButton4_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> openWith = new Dictionary<string, string>();
            string query = "";

/*            artistValidationFormBindingSource.EndEdit();
            ArtistValidationForm artist = artistValidationFormBindingSource.Current as ArtistValidationForm;


            ValidationContext context = new ValidationContext(artist, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(artist, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                {
                    MessageBox.Show(result.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }*/

            openWith.Add("@first", editName.Text);
            openWith.Add("@second", editDbSecond.Text);
            openWith.Add("@third", editDbThird.Text);
            openWith.Add("@fourth", editDbFourth.Text);
            openWith.Add("@five", EditContact.Text);
            openWith.Add("@six", payloadFile);



            if (waitingCreation)
                query = "INSERT INTO artists SET nom = @first, prenom = @second, surnom = @third, age = @fourth, contact_information = @five, payload = @six";
            else
            {
                openWith.Add("@id", selectedId);
                query = "UPDATE artists SET nom = @first, prenom = @second, surnom = @third, age = @fourth, contact_information = @five, payload = @six Where artist_id = @id";
            }

            if (!string.IsNullOrEmpty(payloadFile) && !string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                await loadFile(openFileDialog1.FileName, query, openWith);
            }
            else
            {
                db.executeSqlCommand(query, openWith);
                dataGridView1.DataSource = db.GetValueFromDB("select * from artists");

                MessageBox.Show("Enregistré!");
                resetEdit();
            }

            // if is null need to delete
            if (string.IsNullOrEmpty(editTag.Text))
                return;

            string tag_id = checkTagExist(editTag.Text);
            if (string.IsNullOrEmpty(tag_id))
            {
                Dictionary<string, string> tagArgs = new Dictionary<string, string>();
                tagArgs.Add("@first", editTag.Text);
                tagArgs.Add("@second", "style");
                db.executeSqlCommand("INSERT INTO tags SET nom = @first, type = @second", tagArgs);
                tag_id = checkTagExist(editTag.Text);
            }
            string artist_id = db.getArtist(editName.Text);
            db.createOrUpdateArtistTag(artist_id, tag_id);
        }

        private void resetEdit()
        {
            editName.Text = "";
            editDbSecond.Text = "";
            editDbThird.Text = "";
            editDbFourth.Text = "";
            EditContact.Text = "";
            editName.NullText = "Nom";
            editDbSecond.NullText = "Prenom";
            editDbThird.NullText = "Surnom";
            editDbFourth.NullText = "Age";
            EditContact.NullText = "Instagram";
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            waitingCreation = true;

            resetEdit();
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM artists WHERE artist_id = " + selectedId;

            db.executeSqlCommand(query);
            dataGridView1.DataSource = db.GetValueFromDB("select * from artists");
            resetEdit();
        }

        private void gridview_1DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataManager manager = new DataManager(selectedId, "collections");
            manager.Show();
        }

        private void database_Click(object sender, EventArgs e)
        {

        }

        private async Task loadFile(string filePath, string query, Dictionary<string, string> openWith)
        {
            var multipartFormContent = new MultipartFormDataContent();
            var fileStreamContent = new StreamContent(File.OpenRead(filePath));
            fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            multipartFormContent.Add(fileStreamContent, name: "file", fileName: System.IO.Path.GetFileName(filePath));
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

            var response = await client.PostAsync("http://localhost:8065/api/artists/upload-file/", multipartFormContent);

            if (!response.IsSuccessStatusCode)
            {
                FileRoot uploadHandler = JsonConvert.DeserializeObject<FileRoot>(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine(string.Join(Environment.NewLine, uploadHandler.errors.file));
                MessageBox.Show($"Security error.\n\n{uploadHandler.message}\n\n" + $"Details\n{string.Join(Environment.NewLine, uploadHandler.errors.file)}");
                Console.WriteLine(uploadHandler.errors.file[0]);

                return;
            }

            db.executeSqlCommand(query, openWith);
            dataGridView1.DataSource = db.GetValueFromDB("select * from artists");
        }

        private async void uploadButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                payloadFile = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

                return;
            }
            else if (result != DialogResult.Cancel)
            {
                MessageBox.Show("Error cannot import file.");
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ageTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
