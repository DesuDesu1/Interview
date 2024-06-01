using System.Collections.Concurrent;

namespace Interview
{
    public class Greeter
    {
        private static readonly ConcurrentDictionary<string, bool> m_Visitors = new ConcurrentDictionary<string, bool>();
        private readonly DateTime _currentTime;
        public Greeter(DateTime? currentTime = null)
        {
            _currentTime = currentTime ?? DateTime.Now;
        }
        public void PrintInvitation(string name, bool sex, int friendsCount, bool doNotHaveFriends, string surname)
        {
            try
            {
                if (_currentTime.Hour < 10)
                    Console.WriteLine("Good morning");
                else if (_currentTime.Hour >= 10 && _currentTime.Hour < 20)
                    Console.WriteLine("Good day");
                else
                    Console.WriteLine("Good evening");
                Console.Write(sex ? " Mr " : " Mrs ");
                Console.WriteLine(name + " " + surname + ".");
                Console.WriteLine("We are glad to see you" + (m_Visitors.ContainsKey(name) ? " again.":"."));
                m_Visitors.TryAdd(name, true);
                Console.WriteLine($"We want to invite you { 0} to the party.", doNotHaveFriends? String.Empty: "and your " + friendsCount + " friends");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
