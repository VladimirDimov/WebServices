namespace StringCounter.Service
{
    public class StringCounterService : IStringCounterService
    {

        public int Count(string text, string requestedString)
        {
            var counter = 0;
            int index = -1;

            do
            {
                index++;
                index = text.IndexOf(requestedString, index);
                if (index >= 0)
                {
                    counter++;
                }
            } while (index >= 0);

            return counter;
        }
    }
}
