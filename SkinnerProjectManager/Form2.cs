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


namespace SkinnerProjectManager
{
    public partial class DataManager : MetroForm
    {
        protected string _type;
        protected string _artistId;
        string selectedId = null;
        string previewFile = null;
        string scanFile = null;
        bool waitingCreation = true;
        public DbUtils db;
        string createQuery;
        string updateQuery;
        string deleteQuery;
        string selectQuery;
        public DataManager(string id, string type)
        {
            InitializeComponent();
            _type = type;
            _artistId = id;

            if (type == "tags")
            {
                buttonCreation.Text += "Tag";
                buttonDelete.Text += "Tag";
                editDbFive.Visible = false;
                labelPosition.Visible = false;
                editDbThird.Visible = false;
                labelSurnom.Visible = false;
                labelPayload.Visible = false;
                uploadButton.Visible = false;
                editDbSecond.Text = "Type";
                labelLocation.Text = "Type";
                db = new DbUtils("select * from tags");
                selectQuery = "select * from tags";
                createQuery = "INSERT INTO tags SET nom = @first, type = @second";
                updateQuery = "UPDATE tags SET nom = @first, type = @second where tag_id = @id";
                deleteQuery = "DELETE FROM tags WHERE tag_id = ";
            }
            else if (type == "collections")
            {
                buttonCreation.Text += "Collection";
                buttonDelete.Text += "Collection";
                db = new DbUtils("select * from collections where artist_id = " + _artistId);
                selectQuery = "select * from collections where artist_id = " + _artistId;
                createQuery = "INSERT INTO collections SET nom_court = @first, location = @second, description = @third, payload = @fourth, position = @five, artist_id = " + _artistId;
                updateQuery = "UPDATE collections SET nom_court = @first, location = @second, description = @third, payload = @fourth, position = @five where collection_id = @id";
                deleteQuery = "DELETE FROM collections WHERE collection_id = ";

            }
            dataGridView1.DataSource = db.artistData;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            waitingCreation = false;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            selectedId = row.Cells[0].Value.ToString();
            editName.Text = row.Cells[1].Value.ToString();
            editDbSecond.Text = row.Cells[2].Value.ToString();
            editDbThird.Text = row.Cells[3].Value.ToString();
            previewFile = row.Cells[4].Value.ToString();
            scanFile = row.Cells[4].Value.ToString();
            editDbFive.Text = row.Cells[8].Value.ToString();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            waitingCreation = true;

            resetEdit();
        }

        private async void radButton4_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> openWith = new Dictionary<string, string>();
            string query = "";

            openWith.Add("@first", editName.Text);
            openWith.Add("@second", editDbSecond.Text);

            if (_type == "collections")
            {
                openWith.Add("@third", editDbThird.Text);
                openWith.Add("@fourth", previewFile);
                openWith.Add("@five", editDbFive.Text);
            }

            if (waitingCreation)
                query = createQuery;
            else
            {
                openWith.Add("@id", selectedId);
                query = updateQuery;
            }

            Console.WriteLine(previewFile);
            Console.WriteLine(scanFile);

            if (!string.IsNullOrEmpty(previewFile) && !string.IsNullOrEmpty(scanFile) && !string.IsNullOrEmpty(openFileDialog1.FileName) && !string.IsNullOrEmpty(openFileDialog2.FileName))
            {
                await loadFile(openFileDialog1.FileName, openFileDialog2.FileName, query, openWith);
            }
            else
            {
                db.executeSqlCommand(query, openWith);
                dataGridView1.DataSource = db.GetValueFromDB(selectQuery);

                MessageBox.Show("Enregistré!");
                resetEdit();
            }

        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            string query = deleteQuery + selectedId;

            db.executeSqlCommand(query);
            dataGridView1.DataSource = db.GetValueFromDB(selectQuery);
            resetEdit();
        }
        private void resetEdit()
        {
            if (_type == "tags")
            {
                editName.NullText = "Nom";
                editDbSecond.NullText = "Type";
            }
            else if (_type == "collections")
            {
                editName.NullText = "Nom";
                editDbSecond.NullText = "location";
                editDbThird.NullText = "description";
                editDbFive.NullText = "position";
            }

        }
        private async Task loadFile(string filePath, string secondFilePath, string query, Dictionary<string, string> openWith)
        {
            var multipartFormContent = new MultipartFormDataContent();
            var PreviewStreamContent = new StreamContent(File.OpenRead(filePath));
            var DynamicStreamContent = new StreamContent(File.OpenRead(secondFilePath));
            var client = new HttpClient();

            PreviewStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            DynamicStreamContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            multipartFormContent.Add(PreviewStreamContent, name: "collection_preview", fileName: System.IO.Path.GetFileName(filePath));
            multipartFormContent.Add(DynamicStreamContent, name: "scan", fileName: System.IO.Path.GetFileName(secondFilePath));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
            try
            {
                var response = await client.PostAsync($"http://localhost:8065/api/artist/{_artistId}/upload-files", multipartFormContent);
                Console.WriteLine("status code " + response.StatusCode);


                if (!response.IsSuccessStatusCode)
                {
                    FilesRoot uploadHandler = JsonConvert.DeserializeObject<FilesRoot>(response.Content.ReadAsStringAsync().Result);
                    MessageBox.Show($"Security error.\n\n{uploadHandler.message}\n\n" + $"Details\n{string.Join(string.Join(Environment.NewLine, uploadHandler.errors.scan), string.Join(Environment.NewLine, uploadHandler.errors.collection_preview))}");
                    
                    return;
                }

                db.executeSqlCommand(query, openWith);
                dataGridView1.DataSource = db.GetValueFromDB(selectQuery);

                MessageBox.Show("Enregistré!");
                resetEdit();

            }
            catch (Exception error)
            {
                Console.WriteLine("error: ");
                Console.WriteLine(error.Message);
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                previewFile = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

                return;
            }
            else if (result != DialogResult.Cancel)
            {
                MessageBox.Show("Error cannot import file.");
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog2.ShowDialog();

            if (result == DialogResult.OK)
            {
                scanFile = System.IO.Path.GetFileNameWithoutExtension(openFileDialog2.FileName);

                return;
            }
            else if (result != DialogResult.Cancel)
            {
                MessageBox.Show("Error cannot import file.");
            }
        }
    }
}
