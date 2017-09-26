
namespace NSubstituteStudy.ch18
{
    public class Controller
    {
        private IConnection connection;
        private ICommand command;
        public Controller(IConnection connection, ICommand command)
        {
            this.connection = connection;
            this.command = command;
        }

        public void DoStuff()
        {
            connection.Open();
            command.Run(connection);
            connection.Close();
        }
    }
}
