using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatSongShouldYouListenTo
{
    class MyQuestion
    {
        public String Question { get; set; }
        public List<String> Answers { get; set; }

       public MyQuestion(String q, List<String> a)
        {
            this.Question = q;
            this.Answers = a;
        }
    }
}
