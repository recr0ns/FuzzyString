﻿using FuzzySearch.Core;
using NUnit.Framework;

namespace FuzzySearch.Test
{
    [TestFixture]
    public class LevenshteinDistanceTests : MethodTests
    {
        [SetUp]
        public override void Initialize()
        {
            method = StringComparison.LevenshteinDistance;
        }
    }
}
