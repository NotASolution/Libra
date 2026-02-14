using Domain.ModelPOCO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;


namespace WindowsFormsUI.AdditionRedactionWindows
{
    public partial class MembersARForm : Form
    {
        private byte[] BottledImage;
        private Member SelectedMember { get; set; }
        private bool IsAddition { get; set; } = false;
        private IAdditionRedactionHost Host { get; set; }
        
        public MembersARForm()
        {
            InitializeComponent();
        }

        public MembersARForm(IAdditionRedactionHost host)
        {
            IsAddition = true;
            Host = host;
            
            InitializeComponent();
        }
        public MembersARForm(IAdditionRedactionHost host, Member domainObject)
        {
            
           
            Host = host;

            InitializeComponent();

            PassportNumberTextBox.Text = domainObject.PassportNumber;
            AddressTextBox.Text = domainObject.Address;
            BirthDateTextBox.Text = domainObject.Birthdate.ToString();
            EducationTextBox.Text = domainObject.Education;
            FullnameTextBox.Text = domainObject.FullName;
            MemberIdTextBox.Text = domainObject.MemberId;
            ReadingRoomTextBox.Text = domainObject.ReadingRoomNumber.ToString();
            TelephoneNumberTextBox.Text = domainObject.TelephoneNumber;
            if (domainObject.Photo != null)
                using (MemoryStream ms = new MemoryStream(domainObject.Photo)) MemberPictureBox.Image = Image.FromStream(ms);
            BottledImage = domainObject.Photo;
        }

        private void ImageLoad_Click(object sender, EventArgs e)
        {
            LoadImageIntoPictureBox(MemberPictureBox);

            if (MemberPictureBox.Image != null)
            {
                BottledImage = ImageToByteArray(MemberPictureBox.Image);
                // Now you can store 'data' in DB or do anything you need
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            var k = 
            SelectedMember = new Member()
            {
                PassportNumber = PassportNumberTextBox.Text,
                Address = AddressTextBox.Text,
                Birthdate = Convert.ToDateTime(BirthDateTextBox.Text),
                Education = EducationTextBox.Text,
                Photo = BottledImage ?? null,
                FullName = FullnameTextBox.Text,
                MemberId = MemberIdTextBox.Text,
                ReadingRoomNumber = Convert.ToInt32(ReadingRoomTextBox.Text),
                TelephoneNumber = TelephoneNumberTextBox.Text
            };
            Host.AcceptDomainObject(SelectedMember, IsAddition);
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png); // or Jpeg, Bmp, etc.
                return ms.ToArray();
            }
        }

        private void LoadImageIntoPictureBox(PictureBox pictureBox)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(ofd.FileName);
                }
            }
        }
    }
}
