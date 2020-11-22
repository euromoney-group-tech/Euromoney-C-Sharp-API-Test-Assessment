using EuromoneyAPITest.Models;
using EuromoneyAPITest.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace EuromoneyAPITest.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            // Test data set up (Ensure there are 3 locations before every test)

        }

        [AfterScenario]
        public void AfterScenario()
        {
            
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {          

        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            
        }
    }
}
