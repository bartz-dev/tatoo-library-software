
namespace SkinnerProjectManager
{
    partial class DataManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new Telerik.WinControls.UI.RadButton();
            this.buttonCreation = new Telerik.WinControls.UI.RadButton();
            this.submit = new Telerik.WinControls.UI.RadButton();
            this.labelSurnom = new Telerik.WinControls.UI.RadLabel();
            this.labelLocation = new Telerik.WinControls.UI.RadLabel();
            this.labelName = new Telerik.WinControls.UI.RadLabel();
            this.editDbThird = new Telerik.WinControls.UI.RadTextBoxControl();
            this.editDbSecond = new Telerik.WinControls.UI.RadTextBoxControl();
            this.editName = new Telerik.WinControls.UI.RadTextBoxControl();
            this.labelPosition = new Telerik.WinControls.UI.RadLabel();
            this.editDbFive = new Telerik.WinControls.UI.RadTextBoxControl();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.uploadButton = new MetroFramework.Controls.MetroButton();
            this.labelPayload = new Telerik.WinControls.UI.RadLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCreation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.submit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelSurnom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDbThird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDbSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDbFive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelPayload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(10, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(711, 340);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(847, 63);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(117, 30);
            this.buttonDelete.TabIndex = 34;
            this.buttonDelete.Text = "Supprimer ";
            this.buttonDelete.Click += new System.EventHandler(this.radButton5_Click);
            // 
            // buttonCreation
            // 
            this.buttonCreation.Location = new System.Drawing.Point(727, 63);
            this.buttonCreation.Name = "buttonCreation";
            this.buttonCreation.Size = new System.Drawing.Size(119, 30);
            this.buttonCreation.TabIndex = 33;
            this.buttonCreation.Text = "Créer ";
            this.buttonCreation.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(730, 368);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(235, 35);
            this.submit.TabIndex = 32;
            this.submit.Text = "Enregistrer";
            this.submit.Click += new System.EventHandler(this.radButton4_Click);
            // 
            // labelSurnom
            // 
            this.labelSurnom.Location = new System.Drawing.Point(729, 186);
            this.labelSurnom.Name = "labelSurnom";
            this.labelSurnom.Size = new System.Drawing.Size(45, 18);
            this.labelSurnom.TabIndex = 30;
            this.labelSurnom.Text = "Surnom";
            // 
            // labelLocation
            // 
            this.labelLocation.Location = new System.Drawing.Point(728, 140);
            this.labelLocation.Name = "labelLocation";
            // 
            // 
            // 
            this.labelLocation.RootElement.AutoSize = false;
            this.labelLocation.Size = new System.Drawing.Size(49, 18);
            this.labelLocation.TabIndex = 31;
            this.labelLocation.Text = "Location";
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(729, 94);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(31, 18);
            this.labelName.TabIndex = 28;
            this.labelName.Text = "Nom";
            // 
            // editDbThird
            // 
            this.editDbThird.EmbeddedLabelText = "TEST";
            this.editDbThird.Location = new System.Drawing.Point(730, 205);
            this.editDbThird.Name = "editDbThird";
            this.editDbThird.NullText = "Surnom";
            this.editDbThird.Size = new System.Drawing.Size(235, 22);
            this.editDbThird.TabIndex = 26;
            // 
            // editDbSecond
            // 
            this.editDbSecond.Location = new System.Drawing.Point(730, 158);
            this.editDbSecond.Name = "editDbSecond";
            this.editDbSecond.NullText = "Location";
            this.editDbSecond.Size = new System.Drawing.Size(235, 22);
            this.editDbSecond.TabIndex = 25;
            // 
            // editName
            // 
            this.editName.EmbeddedLabelText = "TEST";
            this.editName.Location = new System.Drawing.Point(730, 112);
            this.editName.Name = "editName";
            this.editName.NullText = "Nom";
            this.editName.Size = new System.Drawing.Size(235, 22);
            this.editName.TabIndex = 24;
            // 
            // labelPosition
            // 
            this.labelPosition.Location = new System.Drawing.Point(730, 233);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(46, 18);
            this.labelPosition.TabIndex = 36;
            this.labelPosition.Text = "Position";
            // 
            // editDbFive
            // 
            this.editDbFive.EmbeddedLabelText = "TEST";
            this.editDbFive.Location = new System.Drawing.Point(731, 251);
            this.editDbFive.Name = "editDbFive";
            this.editDbFive.NullText = "Position";
            this.editDbFive.Size = new System.Drawing.Size(235, 22);
            this.editDbFive.TabIndex = 35;
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Dynamic File (.mp4)|*.mp4|All files (*.*)|*.*";
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(731, 294);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(236, 23);
            this.uploadButton.TabIndex = 38;
            this.uploadButton.Text = "Parcourir";
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // labelPayload
            // 
            this.labelPayload.Location = new System.Drawing.Point(730, 279);
            this.labelPayload.Name = "labelPayload";
            this.labelPayload.Size = new System.Drawing.Size(98, 18);
            this.labelPayload.TabIndex = 39;
            this.labelPayload.Text = "Collection Preview";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(730, 339);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(236, 23);
            this.metroButton1.TabIndex = 40;
            this.metroButton1.Text = "Parcourir";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(730, 323);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(48, 18);
            this.radLabel1.TabIndex = 41;
            this.radLabel1.Text = "3D File\'s";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "3D File (.glb)|*.glb";
            // 
            // DataManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 416);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.labelPayload);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.editDbFive);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonCreation);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.labelSurnom);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.editDbThird);
            this.Controls.Add(this.editDbSecond);
            this.Controls.Add(this.editName);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DataManager";
            this.Text = "Management";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonCreation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.submit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelSurnom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDbThird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDbSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDbFive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelPayload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Telerik.WinControls.UI.RadButton buttonDelete;
        private Telerik.WinControls.UI.RadButton buttonCreation;
        private Telerik.WinControls.UI.RadButton submit;
        private Telerik.WinControls.UI.RadLabel labelSurnom;
        private Telerik.WinControls.UI.RadLabel labelLocation;
        private Telerik.WinControls.UI.RadLabel labelName;
        private Telerik.WinControls.UI.RadTextBoxControl editDbThird;
        private Telerik.WinControls.UI.RadTextBoxControl editDbSecond;
        private Telerik.WinControls.UI.RadTextBoxControl editName;
        private Telerik.WinControls.UI.RadLabel labelPosition;
        private Telerik.WinControls.UI.RadTextBoxControl editDbFive;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroButton uploadButton;
        private Telerik.WinControls.UI.RadLabel labelPayload;
        private MetroFramework.Controls.MetroButton metroButton1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}