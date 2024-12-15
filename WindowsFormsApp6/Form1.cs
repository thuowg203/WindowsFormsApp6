using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            string fontName = toolStripComboBox1.SelectedItem.ToString();
            if (richText.SelectionFont != null)
            {
                richText.SelectionFont = new Font(fontName, richText.SelectionFont.Size, richText.SelectionFont.Style);
            }
            else
            {
                richText.Font = new Font(fontName, richText.Font.Size, richText.Font.Style);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Rich Text Format|*.rtf|Text File|*.txt";
            ofd.Title = "Open a Document";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.Path.GetExtension(ofd.FileName) == ".rtf")
                {
                    richText.LoadFile(ofd.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richText.Text = System.IO.File.ReadAllText(ofd.FileName);
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lưuNộiDungVănBảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Rich Text Format|*.rtf|Text File|*.txt";
            sfd.Title = "Lưu Tài Liệu";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FilterIndex == 1) // Định dạng RTF
                {
                    richText.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);
                }
                else // Định dạng TXT
                {
                    System.IO.File.WriteAllText(sfd.FileName, richText.Text);
                }
            }
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Clear();

            // Đặt lại font chữ về mặc định
            richText.Font = new Font("Tahoma", 14); // Hoặc font và kích thước mặc định mà bạn muốn
            toolStripComboBox1.SelectedItem = "Tahoma"; // Cập nhật ComboBox font
            toolStripComboBox2.SelectedItem = "14"; // Cập nhật ComboBox kích thước

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái hiện tại của văn bản đang chọn
            if (richText.SelectionFont != null)
            {
                Font currentFont = richText.SelectionFont;
                FontStyle newFontStyle;

                // Xác định kiểu chữ mới
                if (currentFont.Bold)
                {
                    newFontStyle = currentFont.Style & ~FontStyle.Bold; // Bỏ in đậm
                }
                else
                {
                    newFontStyle = currentFont.Style | FontStyle.Bold; // Thêm in đậm
                }

                // Áp dụng kiểu chữ mới cho văn bản đang chọn
                richText.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                Font currentFont = richText.SelectionFont;
                FontStyle newFontStyle;

                if (currentFont.Italic)
                {
                    newFontStyle = currentFont.Style & ~FontStyle.Italic; // Bỏ in nghiêng
                }
                else
                {
                    newFontStyle = currentFont.Style | FontStyle.Italic; // Thêm in nghiêng
                }

                richText.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                Font currentFont = richText.SelectionFont;
                FontStyle newFontStyle;

                if (currentFont.Underline)
                {
                    newFontStyle = currentFont.Style & ~FontStyle.Underline; // Bỏ gạch dưới
                }
                else
                {
                    newFontStyle = currentFont.Style | FontStyle.Underline; // Thêm gạch dưới
                }

                richText.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void taovanban_Click(object sender, EventArgs e)
        {
            richText.Clear();

            // Đặt lại font chữ về mặc định
            richText.Font = new Font("Tahoma", 14);
            toolStripComboBox1.SelectedItem = "Tahoma";
            toolStripComboBox2.SelectedItem = "14";
        }

        private void luu_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Rich Text Format|*.rtf|Text File|*.txt";
            sfd.Title = "Lưu Tài Liệu";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FilterIndex == 1) // Định dạng RTF
                {
                    richText.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);
                }
                else // Định dạng TXT
                {
                    System.IO.File.WriteAllText(sfd.FileName, richText.Text);
                }
            }
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            float fontSize = float.Parse(toolStripComboBox2.SelectedItem.ToString());
            if (richText.SelectionFont != null)
            {
                richText.SelectionFont = new Font(richText.SelectionFont.FontFamily, fontSize, richText.SelectionFont.Style);
            }
            else
            {
                richText.Font = new Font(richText.Font.FontFamily, fontSize, richText.Font.Style);
            }
        }
    }
}
