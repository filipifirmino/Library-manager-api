namespace LibraryManager.Web.Requests;

public class AuthorCreateRequet
{
    public string Name { get; set; }
    public string Biografi { get; set; }
    public DateTime Birth { get; set; }
}