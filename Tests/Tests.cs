using System;
using NUnit.Framework;
using RouteOptimizer;

namespace Tests
{
    public class Tests
    {
        #region Correct Tests
        [Test]
        public void OptimizeTest9RouteArray()
        {
            var unsortedRoutes = new Route[]
            {
                new Route { From = Area.Arbat, To = Area.Basmanny },
                new Route { From = Area.Khamovniki, To = Area.Krasnoselsky },
                new Route { From = Area.Basmanny, To = Area.Khamovniki },
                new Route { From = Area.Yakimanka, To = Area.Zamoskvorechye },
                new Route { From = Area.Tagansky, To = Area.Tverskoy },
                new Route { From = Area.Meshchansky, To = Area.Presnensky },
                new Route { From = Area.Krasnoselsky, To = Area.Meshchansky },
                new Route { From = Area.Presnensky, To = Area.Tagansky },
                new Route { From = Area.Tverskoy, To = Area.Yakimanka }
            };

            var sortedRoutes = new Route[]
            {
                new Route { From = Area.Arbat, To = Area.Basmanny },
                new Route { From = Area.Basmanny, To = Area.Khamovniki },
                new Route { From = Area.Khamovniki, To = Area.Krasnoselsky },
                new Route { From = Area.Krasnoselsky, To = Area.Meshchansky },
                new Route { From = Area.Meshchansky, To = Area.Presnensky },
                new Route { From = Area.Presnensky, To = Area.Tagansky },
                new Route { From = Area.Tagansky, To = Area.Tverskoy },
                new Route { From = Area.Tverskoy, To = Area.Yakimanka },
                new Route { From = Area.Yakimanka, To = Area.Zamoskvorechye }
            };

            Assert.AreEqual(sortedRoutes, Optimizer.Optimize(unsortedRoutes));
        }

        [Test]
        public void OptimizeTest6RouteArray()
        {
            var unsortedRoutes = new Route[]
            {
                new Route { From = Area.Arbat, To = Area.Basmanny },
                new Route { From = Area.Khamovniki, To = Area.Krasnoselsky },
                new Route { From = Area.Basmanny, To = Area.Khamovniki },
                new Route { From = Area.Meshchansky, To = Area.Presnensky },
                new Route { From = Area.Krasnoselsky, To = Area.Meshchansky },
                new Route { From = Area.Presnensky, To = Area.Tagansky }
            };

            var sortedRoutes = new Route[]
            {
                new Route { From = Area.Arbat, To = Area.Basmanny },
                new Route { From = Area.Basmanny, To = Area.Khamovniki },
                new Route { From = Area.Khamovniki, To = Area.Krasnoselsky },
                new Route { From = Area.Krasnoselsky, To = Area.Meshchansky },
                new Route { From = Area.Meshchansky, To = Area.Presnensky },
                new Route { From = Area.Presnensky, To = Area.Tagansky }
            };

            Assert.AreEqual(sortedRoutes, Optimizer.Optimize(unsortedRoutes));
        }

        [Test]
        public void OptimizeTest4RouteArray()
        {
            var unsortedRoutes = new Route[]
            {
                new Route { From = Area.Arbat, To = Area.Basmanny },
                new Route { From = Area.Khamovniki, To = Area.Krasnoselsky },
                new Route { From = Area.Krasnoselsky, To = Area.Meshchansky },
                new Route { From = Area.Basmanny, To = Area.Khamovniki }
            };

            var sortedRoutes = new Route[]
            {
                new Route { From = Area.Arbat, To = Area.Basmanny },
                new Route { From = Area.Basmanny, To = Area.Khamovniki },
                new Route { From = Area.Khamovniki, To = Area.Krasnoselsky },
                new Route { From = Area.Krasnoselsky, To = Area.Meshchansky }
            };

            Assert.AreEqual(sortedRoutes, Optimizer.Optimize(unsortedRoutes));
        }

        [Test]
        public void OptimizeTest3RouteArray()
        {
            var unsortedRoutes = new Route[]
            {
                new Route { From = Area.Arbat, To = Area.Basmanny },
                new Route { From = Area.Khamovniki, To = Area.Krasnoselsky },
                new Route { From = Area.Basmanny, To = Area.Khamovniki }
            };

            var sortedRoutes = new Route[]
            {
                new Route { From = Area.Arbat, To = Area.Basmanny },
                new Route { From = Area.Basmanny, To = Area.Khamovniki },
                new Route { From = Area.Khamovniki, To = Area.Krasnoselsky }
            };

            Assert.AreEqual(sortedRoutes, Optimizer.Optimize(unsortedRoutes));
        }

        [Test]
        public void OptimizeTest2RouteArray()
        {
            var unsortedRoutes = new Route[]
            {
                new Route { From = Area.Basmanny, To = Area.Khamovniki },
                new Route { From = Area.Arbat, To = Area.Basmanny }
            };

            var sortedRoutes = new Route[]
            {
                new Route { From = Area.Arbat, To = Area.Basmanny },
                new Route { From = Area.Basmanny, To = Area.Khamovniki }
            };

            Assert.AreEqual(sortedRoutes, Optimizer.Optimize(unsortedRoutes));
        }
        #endregion

        #region Incorrect Tests
        [Test]
        public void OptimizeTest1RouteArray()
        {
            var unsortedRoutes = new Route[]
            {
                new Route { From = Area.Arbat, To = Area.Basmanny }
            };

            string exceptionMessageFromProgram = "";

            try
            {
                Optimizer.Optimize(unsortedRoutes);
            }
            catch (Exception e)
            {
                exceptionMessageFromProgram = e.Message;
            }

            Assert.AreEqual(Optimizer.exceptionMessageArrayIsEmptyOrInclude1Route, exceptionMessageFromProgram);
        }

        [Test]
        public void OptimizeTestEmptyRouteArray()
        {
            var unsortedRoutes = new Route[0];

            string exceptionMessageFromProgram = "";

            try
            {
                Optimizer.Optimize(unsortedRoutes);
            }
            catch (Exception e)
            {
                exceptionMessageFromProgram = e.Message;
            }

            Assert.AreEqual(Optimizer.exceptionMessageArrayIsEmptyOrInclude1Route, exceptionMessageFromProgram);
        }

        [Test]
        public void OptimizeTestWithDuplicatesRouteArray()
        {
            var unsortedRoutes = new Route[]
            {
                new Route { From = Area.Basmanny, To = Area.Khamovniki },
                new Route { From = Area.Basmanny, To = Area.Khamovniki }
            };

            string exceptionMessageFromProgram = "";

            try
            {
                Optimizer.Optimize(unsortedRoutes);
            }
            catch (Exception e)
            {
                exceptionMessageFromProgram = e.Message;
            }

            Assert.AreEqual(Optimizer.exceptionMessageIncorrectData, exceptionMessageFromProgram);
        }

        [Test]
        public void OptimizeTestWithUnrelatedRouteArray()
        {
            var unsortedRoutes = new Route[]
            {
                new Route { From = Area.Arbat, To = Area.Basmanny },
                new Route { From = Area.Khamovniki, To = Area.Krasnoselsky }
            };

            string exceptionMessageFromProgram = "";

            try
            {
                Optimizer.Optimize(unsortedRoutes);
            }
            catch (Exception e)
            {
                exceptionMessageFromProgram = e.Message;
            }

            Assert.AreEqual(Optimizer.exceptionMessageIncorrectData, exceptionMessageFromProgram);
        }

        [Test]
        public void OptimizeTestWithIncorrectRouteArray()
        {
            var unsortedRoutes = new Route[]
            {
                new Route { From = Area.Arbat, To = Area.Basmanny },
                new Route()
            };

            string exceptionMessageFromProgram = "";

            try
            {
                Optimizer.Optimize(unsortedRoutes);
            }
            catch (Exception e)
            {
                exceptionMessageFromProgram = e.Message;
            }

            Assert.AreEqual(Optimizer.exceptionMessageIncorrectRoute, exceptionMessageFromProgram);
        }
        #endregion
    }
}