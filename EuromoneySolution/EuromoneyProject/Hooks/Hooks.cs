using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace EuromoneyProject.Hooks
{
    [Binding]
    public sealed class Hooks
    {

        [Before]
        public void Before()
        {
            Console.WriteLine("execute before each scenario");

        }

        [After]
        public void After()
        {
            Console.WriteLine("execute after each scenario");

        }


        [BeforeScenario(Order = 0)]
        [Scope(Tag = "login")]

        public void BeforeScenario()
        {
            Console.WriteLine("login tag before scenario");

        }

        [AfterScenario]
        [Scope(Tag = "login")]

        public void AfterScenario()
        {
            Console.WriteLine("login tag after scenario");

        }


        [BeforeStep]
        public void BeforeStep()
        {
            Console.WriteLine("execute before each step");


        }

        [AfterStep]
        public void AfterStep()
        {
            Console.WriteLine("execute after each step");

        }
    }
}
