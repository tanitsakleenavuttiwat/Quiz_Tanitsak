namespace Quiz_Tanitsak_Api.Models.Entity
{
    public class GetImformationUserViewModel
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<GetImformationUserViewResp> getImformationUserViewResps { get; set; }
    }

    public class GetImformationUserViewResp
    {
        public int? userId { get; set; }
        public string fullName { get; set; }
        public string birthday { get; set; }
        public int? age { get; set; }
    }
}
