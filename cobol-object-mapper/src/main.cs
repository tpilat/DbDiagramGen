// main demo application driver for Cobol Object Mapper
// author: Christophe VG <contact@christophe.vg>

using System;
using System.IO;
using System.Collections.Generic;

using System.Linq;

namespace Cobol_Object_Mapper {

  public class Importer {
    
    public static void Main(string[] args) {

      string input = null;
      bool   dot   = false;

      if(args.Length > 0) {
        foreach(string arg in args) {
          if( arg.Equals("-d") || arg.Equals("--dot") ) {
            dot = true;
          } else if( ! File.Exists(arg) ) {
            Console.Error.WriteLine("WARNING: Unknown file: " + arg);
          } else {
            Console.Error.WriteLine("*** Importing " + arg);
            input += System.IO.File.ReadAllText(arg);
          }
        }
      }

      // no input from files ... try stdin
      if(input == null) {
        Console.Error.WriteLine("*** Reading from stdin...");
        string s;
        while( (s = Console.ReadLine()) != null ) {
          input += s;
        }
      }
    
      if(input == null) {
        Console.Error.WriteLine("ERROR: No input detected.");
        return;
      }

      Console.Error.WriteLine("*** Mapping...");
      Mapper mapper = new Mapper();
      try {
        mapper.Parse(input);
      } catch(ParseException e) {
        // recurse down the Exception tree, to reach the most specific one
        while(e.InnerException != null) {
          e = e.InnerException as ParseException;
        } 
        Console.Error.WriteLine(e.Message);
        return;
      }

      if(dot) {
        Console.Error.WriteLine("*** Dumping Dot format");
        Console.WriteLine(mapper.Model.Dotify());
      } else {
        Console.Error.WriteLine("*** Dumping Text format");
        Console.WriteLine(mapper.Model.ToString());
      }
    }

  }
}
