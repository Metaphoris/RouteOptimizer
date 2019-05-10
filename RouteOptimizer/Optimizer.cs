using System;
using System.Collections.Generic;

namespace RouteOptimizer
{
    public static class Optimizer
    {
        public const string exceptionMessageIncorrectData = "Возникла проблема, проверьте входные данные на предмет циклов и пропусков";
        public const string exceptionMessageIncorrectRoute = "Возникла проблема, проверьте маршруты в цепочке";
        public const string exceptionMessageArrayIsEmptyOrInclude1Route = "Возникла проблема, входящие данные пусты или содержат только один маршрут";

        public static Route[] Optimize(Route[] unsortedRoutes)
        {
            if ((unsortedRoutes.Length == 0) || (unsortedRoutes.Length == 1))
            {
                throw new Exception(exceptionMessageArrayIsEmptyOrInclude1Route);
            }

            if (RouteIncorrect(unsortedRoutes[0]))
            {
                throw new Exception(exceptionMessageIncorrectRoute);
            }

            Deque<Route> sortedRoutes = new Deque<Route>
            {
                unsortedRoutes[0]
            };
            int iteration = 1;

            while (sortedRoutes.Count < unsortedRoutes.Length)
            {
                if (iteration > unsortedRoutes.Length)
                {
                    break;
                }

                for (int i = 1; i < unsortedRoutes.Length; i++)
                {
                    if (RouteIncorrect(unsortedRoutes[i]))
                    {
                        throw new Exception(exceptionMessageIncorrectRoute);
                    }
                    if (sortedRoutes.Count == 1)
                    {
                        if (Match(sortedRoutes[0], unsortedRoutes[i]))
                        {
                            sortedRoutes.AddBack(unsortedRoutes[i]);
                        }
                        else if (Match(unsortedRoutes[i], sortedRoutes[0]))
                        {
                            sortedRoutes.AddFront(unsortedRoutes[i]);
                        }
                    }
                    else
                    {
                        if (Match(sortedRoutes[sortedRoutes.Count - 1], unsortedRoutes[i]))
                        {
                            sortedRoutes.AddBack(unsortedRoutes[i]);
                        }
                        else if (Match(unsortedRoutes[i], sortedRoutes[0]))
                        {
                            sortedRoutes.AddFront(unsortedRoutes[i]);
                        }
                    }
                }

                iteration++;
            }

            if ((sortedRoutes.Count == unsortedRoutes.Length) && (iteration <= unsortedRoutes.Length))
            {
                sortedRoutes.CopyTo(unsortedRoutes, 0);
            }
            else
            {
                throw new Exception(exceptionMessageIncorrectData);
            }

            return unsortedRoutes;
        }

        private static bool Match(Route prevRoute, Route nextRoute)
        {
            return prevRoute.To == nextRoute.From;
        }

        private static bool RouteIncorrect(Route route)
        {
            return route.From == route.To;
        }
    }
}