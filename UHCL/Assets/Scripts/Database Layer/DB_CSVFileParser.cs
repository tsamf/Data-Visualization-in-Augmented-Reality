﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static  class DB_CSVFileParser {
    
    //public static List<string[]> readfile(string path, bool removeHeader)
    //{

    //    StreamReader reader = new StreamReader(path);
    //    List<string[]> rows = new List<string[]>();

    //    //If file has header and needs to be removed remove it.
    //    if (removeHeader && !reader.EndOfStream)
    //    {
    //        reader.ReadLine();
    //    }

    //    while (!reader.EndOfStream)
    //    {
    //        string[] row = reader.ReadLine().Split(',');
    //        rows.Add(row);
    //    }

    //    reader.Close();

    //    return rows;
    //}

    //public static void WriteFile(string path, List<string[]> rows)
    //{
    //    StreamWriter writer = new StreamWriter(path);

    //    foreach (string[] r in rows)
    //    {
    //        string row = "";
    //        for (int i = 0; i < r.Length; i++)
    //        {
    //            //Last value dont add comma at the end
    //            if (i == r.Length - 1)
    //            {
    //                row += (r[i]);
    //            }
    //            else
    //            {
    //                row += (r[i] + ",");
    //            }

    //        }

    //        writer.WriteLine(row);
    //    }

    //    writer.Close();
    //}
}