namespace LegacyApp;

public interface ICreditProcessor
{
    public string Type { get;  }
    
    bool ProcessCredit(User user,Client client);
}