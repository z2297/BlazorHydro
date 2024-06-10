using Hydro;
using HydroDemo.EventModels;

namespace HydroDemo.Pages.Components
{
    public class Summary : HydroComponent
    {
        public string Text { get; set; } = "The button was clicked 0 times";

        public Summary()
        {
            Subscribe<CountChangedEvent>(Handle);
        }


        public void Handle(CountChangedEvent countEvent)
        {
            Text = $"The {countEvent.Key} was clicked {countEvent.Count} time(s)";
        }
    }
}
