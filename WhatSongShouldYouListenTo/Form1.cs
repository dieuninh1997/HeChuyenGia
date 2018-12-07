using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatSongShouldYouListenTo
{
    public partial class Form1 : Form
    {

        List<MyQuestion> questionList = new List<MyQuestion>();
        private Stack<MyAnswer> myAnswers = new Stack<MyAnswer>();
        private Dictionary<String, String> description = new Dictionary<string, string>();
        private int currentQuestion = -1;

        private List<String> key = new List<string>()
        {
            "how_tam_trang",
            "which_language",
            "what_the_loai"
        };

        private MyProlog prolog;
        private const String prologFilePath = @"..\..\Prolog_Code.pl";

        public Form1()
        {
            InitializeComponent();
            // Init & Load prolog file
            prolog = new MyProlog();
            prolog.LoadFile(prologFilePath);
            //Build List question
            buildListQuestion();
        }
        private void buildListQuestion()
        {
            // 0
            questionList.Add(new MyQuestion("How do you feel now?",
                new List<string>() { "Rainning", "Bored", "I don't know",
                "Thu gian", "Dong luc"}));
            // 1
            questionList.Add(new MyQuestion("Which country do you listen to?",
                new List<string>() { "Vietnam", "US"}));
            // 2
            questionList.Add(new MyQuestion("What gern do you like?", 
                new List<string>() { "Nhac Pop", "Country", "EDM", "Khong loi"}));
           

            description.Add("cry_over_you", "Cry over you - JustaTee, Binz - https://www.youtube.com/watch?v=BhI0XegF7o4");
            description.Add("die_a_happy_man", "Die a happy man - Thomas Rhett - https://www.youtube.com/watch?v=UZmj8rrk6bg");
            description.Add("shots", "Shots (Broiler Remix) - Imagine Dragons - https://www.youtube.com/watch?v=UcHJtgljXEo");
            description.Add("love_me_tender", "Love me tender - Piano - https://www.youtube.com/watch?v=TepTGONg0yE");
            description.Add("nhin_vao_mua", "Nhin vao mua (Em gai mua OST) - Trung Quan Idol - https://www.youtube.com/watch?v=ltAnEOtGajs ");
            description.Add("va_toi_hat", "Va toi hat - Monstar - https://www.youtube.com/watch?v=DHnbkEMg15s");
            description.Add("heres_to_never_growing_up", "Here's to never growing up - Avril Lavigne - https://www.youtube.com/watch?v=sXd2WxoOP5g ");
            description.Add("something_just_like_this", "The Chainsmokers & Coldplay - Something Just Like This (Lyric) - https://www.youtube.com/watch?v=FM7MFYoylVs ");
            description.Add("come_in_with_the_rain", "Come in with the rain -  Taylor Swift - https://www.youtube.com/watch?v=qxW5ZS8UgJc");
            description.Add("when_the_love_falls", "When the love falls (Piano) - Yiruma - https://www.youtube.com/watch?v=rDzDvP0dEBU");
            description.Add("rain", "S1LVA - Rain (Feat. Alina Renae) - https://www.youtube.com/watch?v=lE_B8DteIyk");
        }


        private void BindQuestion(int index)
        {
            HideRadioButton();
            lbQuestion.Text = questionList[index].Question;
            for (int i = 0; i < questionList[index].Answers.Count; i++)
            {
                RadioButton c = (RadioButton)this.Controls.Find("rd" + (i + 1), true).FirstOrDefault();
                c.Text = questionList[index].Answers[i];
                c.Visible = true;
            }
        }

        private void HideRadioButton()
        {
            rd1.Visible = false;
            rd2.Visible = false;
            rd3.Visible = false;
            rd4.Visible = false;
            rd5.Visible = false;
        }

        private String GetResult(String ans)
        {
            return ans.Replace(" ", "_").Replace("'", "").ToLower();
        }
        private int QuestionControl(int index, String ans)
        {
            int current = -1;
            switch (index)
            {
                case 0:
                    if (ans.Equals("rainning")||ans.Equals("thu_gian")||ans.Equals("dong_luc")) {
                        BindQuestion(1);
                        current = 1;
                    }
                    break;
                case 1:
                    if (ans.Equals("vietnam")||ans.Equals("us")) {
                        BindQuestion(2);
                        current = 2;
                    }
                    break;
                case 2:
                    break;
            }
            return current;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            groupBox1.Visible = true;
            label2.Visible = false;
            currentQuestion = 0;
            BindQuestion(0);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (rd1.Checked) {
                myAnswers.Push(
                    new MyAnswer(currentQuestion, GetResult(rd1.Text)));
                currentQuestion = QuestionControl(currentQuestion, GetResult(rd1.Text));
            }
            else if (rd2.Checked) {
                myAnswers.Push(
                    new MyAnswer(currentQuestion, GetResult(rd2.Text)));
                currentQuestion = QuestionControl(currentQuestion, GetResult(rd2.Text));
            }
            else if (rd3.Checked) {
                myAnswers.Push(
                    new MyAnswer(currentQuestion, GetResult(rd3.Text)));
                currentQuestion = QuestionControl(currentQuestion, GetResult(rd3.Text));
            }
            else if (rd4.Checked) {
                myAnswers.Push(
                    new MyAnswer(currentQuestion, GetResult(rd4.Text)));
                currentQuestion = QuestionControl(currentQuestion, GetResult(rd4.Text));
            }
            else if (rd5.Checked) {
                myAnswers.Push(
                    new MyAnswer(currentQuestion, GetResult(rd5.Text)));
                currentQuestion = QuestionControl(currentQuestion, GetResult(rd5.Text));
            }


            if (currentQuestion == -1)
            {
                String query = "";
                String history = "";
                while (myAnswers.Count > 0)
                {
                    MyAnswer ma = myAnswers.Pop();
                   // MessageBox.Show(myAnswers.Count+"  "+ma.QuestionIndex+" "+ma.Answer);
                    //MessageBox.Show("key=" + key[ma.QuestionIndex] + ", ma.answer="+ma.Answer);
                    query = key[ma.QuestionIndex] + "('" + ma.Answer + "')," + query;
                    history = "---------------------------------------------------\r\n" + history;
                    history = "[A] " + ma.Answer + "\r\n" + history;
                    history = "[Q] " + questionList[ma.QuestionIndex].Question + "\r\n" + history;
                  
                }
              

                query = query.Substring(0, query.Length - 1);
                query = "song(X, " + query + ").";
               // MessageBox.Show(query);
                try
                {
                   // MessageBox.Show(prolog.GetResult(query));
                    string result = description[prolog.GetResult(query)];
                    MessageBox.Show(result, "Hey!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("View your question history?", "View History", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        history += "System result:\r\n" + result;
                        new Form2(history).ShowDialog();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnStart.Visible = true;
            groupBox1.Visible = false;
            label2.Visible = true;
            myAnswers.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (myAnswers.Count > 0)
            {
                currentQuestion = myAnswers.Peek().QuestionIndex;
                BindQuestion(currentQuestion);
                myAnswers.Pop();
            }
        }
    }
}
