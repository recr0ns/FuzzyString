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
    public class LongestCommonSubsequenceMethod : ISearchMethod
    {
        public static int ComputeLCS(string str1, string str2)
        {
            int[,] table;
            return ComputeLCSInternal(str1, str2, out table);
        }

        private static int ComputeLCSInternal(string str1, string str2, out int[,] matrix)
        {
            matrix = null;

            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
            {
                return 0;
            }

            var table = new int[str1.Length + 1, str2.Length + 1];
            for (var i = 0; i < table.GetLength(0); i++)
            {
                table[i, 0] = 0;
            }
            for (var j = 0; j < table.GetLength(1); j++)
            {
                table[0, j] = 0;
            }

            for (var i = 1; i < table.GetLength(0); i++)
            {
                for (var j = 1; j < table.GetLength(1); j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                        table[i, j] = table[i - 1, j - 1] + 1;
                    else
                    {
                        if (table[i, j - 1] > table[i - 1, j])
                            table[i, j] = table[i, j - 1];
                        else
                            table[i, j] = table[i - 1, j];
                    }
                }
            }

            matrix = table;
            return table[str1.Length, str2.Length];
        }

        public double GetRate(string arg1, string arg2)
        {
            return (double) ComputeLCS(arg1, arg2)/Math.Max(arg1.Length, arg2.Length);
        }
    }
}