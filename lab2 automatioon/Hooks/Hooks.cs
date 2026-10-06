using lab2_automatioon.Drivers;
using TechTalk.SpecFlow;

namespace lab2_automatioon.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly WebDriverContext _driverContext;

        public Hooks(WebDriverContext driverContext)
        {
            _driverContext = driverContext;
        }

        [AfterScenario]
        public void TearDown()
        {
            _driverContext.Driver?.Quit();
            _driverContext.Driver?.Dispose();
        }
    }
}