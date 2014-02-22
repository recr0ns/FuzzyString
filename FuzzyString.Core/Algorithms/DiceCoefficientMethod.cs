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
using System.Collections.Generic;

namespace FuzzySearch.Core.Algorithms
{
    internal class DiceCoefficientMethod : ISearchMethod
    {
        private static HashSet<string> GetBigramms(string input)
        {
            var bigramms = new HashSet<string>();
            for (var i = 0; i < input.Length - 1; i++)
            {
                bigramms.Add(input.Substring(i, 2));
            }
            return bigramms;
        }

        private static double ComputeDiceCoefficient(string arg1, string arg2)
        {
            var nx = GetBigramms(arg1);
            var ny = GetBigramms(arg2);
            
            var intersection = new HashSet<string>(nx);
            intersection.IntersectWith(ny);

            double dbOne = intersection.Count;
            return (2 * dbOne) / (nx.Count + ny.Count);
        }

        public double GetRate(string arg1, string arg2)
        {
            return ComputeDiceCoefficient(arg1, arg2);
        }
    }
}