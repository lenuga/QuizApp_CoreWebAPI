using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuizApp_CoreWebAPI.Models
{
    public partial class McqQuestion
    {
        public int McqId { get; set; }
        public string QuestionNo { get; set; }
        public string Question { get; set; }
        public string QuizType { get; set; }
        public string Img { get; set; }
        public string ExtraAnswer { get; set; }
        public string Ans { get; set; }
    }
}
