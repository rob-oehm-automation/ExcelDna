﻿using ExcelDna.PackedResources;
using NUnit.Framework;
using System.IO;

namespace ExcelDna.PackedResourcesTests
{
    public class ExcelDnaPackTests
    {
        [Test]
        public void Pack()
        {
            string dnaFile = TestdataHelper.FilePath("test_pack-AddIn.dna");
            string xllFile = TestdataHelper.FilePath("test_pack-AddIn.xll");
            string outPath = TestdataHelper.FilePath("ExcelDnaPackTests-AddIn64-packed-out.dll");
            File.Copy(TestdataHelper.FilePath("AddIn64.dll"), xllFile, true);
            ExcelDnaPack.Pack(dnaFile, outPath, true, false, true, null, null);

            Assert.That(File.ReadAllBytes(outPath), Is.EqualTo(File.ReadAllBytes(TestdataHelper.FilePath("AddIn64-packed.dll"))));
            File.Delete(outPath);
            File.Delete(xllFile);
        }
    }
}
