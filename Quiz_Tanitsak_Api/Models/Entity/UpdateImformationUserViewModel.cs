namespace Quiz_Tanit_API.Models.Entity
{
    public class UpdateImformationUserViewModel
    {
        public string status { get; set; }
        public string message { get; set; }
    }

    public  class UpdateImformationUserViewReq
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string birthday { get; set; }
        public string address { get; set; }
    }
}
