/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;

namespace FuzzySearch.Core.Algorithms
{
    internal class LevenshteinDistanceMethod : ISearchMethod
    {
        private static double ComputeLevenshteinDistance(string arg1, string arg2)
        {
            var sa = arg1.ToCharArray();
            var n = sa.Length;
            var p = new int[n + 1];
            var d = new int[n + 1];
            var m = arg2.Length;

            if (n == 0 || m == 0)
            {
                return n == m ? 1 : 0;
            }

            int i; 
            int j;

            for (i = 0; i <= n; i++)
            {
                p[i] = i;
            }

            for (j = 1; j <= m; j++)
            {
                var t_j = arg2[j - 1];
                d[0] = j;

                for (i = 1; i <= n; i++)
                {
                    var cost = sa[i - 1] == t_j ? 0 : 1;
                    d[i] = Math.Min(Math.Min(d[i - 1] + 1, p[i] + 1), p[i - 1] + cost);
                }

                var _d = p;
                p = d;
                d = _d;
            }

            return 1.0d - ((double) p[n]/Math.Max(arg2.Length, sa.Length));
        }

        public double GetRate(string arg1, string arg2)
        {
            return ComputeLevenshteinDistance(arg1, arg2);
        }
    }
}