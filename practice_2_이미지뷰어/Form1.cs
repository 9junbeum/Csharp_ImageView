using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice_2_이미지뷰어
{
    public partial class Form1 : Form
    {
        // 불러올 폴더 브라우저 띄워서 정보 담는 변수
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //폴더 브라우저로 부터 정보를 받아 가지고오면,
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                //선택된 주소를 textbox1에 표시
                textBox1.Text = folderBrowserDialog.SelectedPath;
                //파일 목록 표시하는 곳 깨끗이 리셋하고
                listBox1.Items.Clear();
                //새로 받아온 목록 표시
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(folderBrowserDialog.SelectedPath);
                System.IO.FileInfo[] fi = di.GetFiles();
                
                foreach(System.IO.FileInfo f in fi)
                {
                    if(f.Extension == ".jpg" || f.Extension == ".jpeg" || f.Extension == ".gif" || f.Extension == ".png" || f.Extension == ".jfif")
                    {
                        listBox1.Items.Add(f);
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //인덱스 저장할 변수
            int selectedIndex = -1;

            //마우스 포인터 위치
            Point point = e.Location;

            selectedIndex = listBox1.IndexFromPoint(point);

            if(selectedIndex != -1)
            {
                string selectedItem = listBox1.Items[selectedIndex].ToString();
                string whatisfile = folderBrowserDialog.SelectedPath.ToString() + "\\" + selectedItem.ToString();
                pictureBox1.Image = Image.FromFile(whatisfile);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
