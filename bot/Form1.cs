using Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bot
{
    public partial class Form1 : Form
    {
        private ChatBot chatbot = new ChatBot();
        private string resp;
        private Text texto;
        private TextBox[] caixaTexto = null;
        private bool falar = true;

        public Form1()
        {
            InitializeComponent();
            texto = new Text();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            int index;

            if (caixaTexto == null)
                index = 0;
            else
                index = caixaTexto.Length;

            if ((e.KeyCode == Keys.Enter) && textBox1.Text != "")
            {
                if (index == 0)
                    texto.InsertLine("", -1);
                else
                    texto.InsertLine(textBox1.Text, index);

                resp = chatbot.categoria(textBox1.Text, falar);
                pTexto.VerticalScroll.Value = 0;
                DrawText(true, textBox1.Text);
                texto.InsertLine(resp, caixaTexto.Length);
                DrawText(false, resp);
                pTexto.ScrollControlIntoView(caixaTexto[index+1]);
                textBox1.Clear();
                SendKeys.Send("{BS}");
            }

        }

        private void DrawText(bool usr, string frase)
        {
            caixaTexto = new TextBox[texto.NumLines];
            LinkedListNode<string> n = texto.FirstLine;
            int i = 0;
            

            while (n != null)
            {
                caixaTexto[i] = new TextBox();
                if (usr)
                {
                    caixaTexto[i].BackColor = Color.FromKnownColor(KnownColor.Control);
                    caixaTexto[i].ForeColor = Color.Blue;
                    caixaTexto[i].Text += "usuário: ";
                }
                else
                {
                    caixaTexto[i].BackColor = Color.FromKnownColor(KnownColor.Control);
                    caixaTexto[i].ForeColor = Color.Green;
                    caixaTexto[i].Text += "bot: ";
                }
                caixaTexto[i].Multiline = true;
                if (i == 0)
                    caixaTexto[i].Location = new Point(3, 3);
                else
                    caixaTexto[i].Location = new Point(3, (3 * 10 * i));
                caixaTexto[i].Font = new Font("Arial", 11);
                caixaTexto[i].Width = 420;
                caixaTexto[i].Height = 25;
                caixaTexto[i].BorderStyle = BorderStyle.None;
                caixaTexto[i].Font = new Font(caixaTexto[i].Font, FontStyle.Bold);
                caixaTexto[i].Text += frase;
                caixaTexto[i].Tag = i.ToString();
                caixaTexto[i].ReadOnly = true;

                pTexto.Controls.Add(caixaTexto[i]);

                n = n.Next;
                i++;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            falar = !falar;
            if (falar)
                button1.Text = "Voz: ligado";
            else
                button1.Text = "Voz: desligado";
        }
    }
}
