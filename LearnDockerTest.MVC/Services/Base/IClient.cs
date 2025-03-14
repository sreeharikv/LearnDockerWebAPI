namespace LearnDockerTest.MVC.Services.Base;

public partial interface IClient
{
    public HttpClient HttpClient { get; }
}
