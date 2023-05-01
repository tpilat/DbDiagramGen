// unit tests for Cobol Object Mapper
// author: Christophe VG <contact@christophe.vg>

using System;
using NUnit.Framework;

namespace Cobol_Object_Mapper {

  [TestFixture]
  public class MapperTest {
    Mapper mapper;

    [SetUp]
    public void SetUp() {
      this.mapper = new Mapper();
    }

    [TearDown]
    public void TearDown() {
      this.mapper = null;
    }

    private Model mapAndCompare(string input, string expected) {
      Assert.AreEqual( expected.Trim(), mapper.Parse(input).Model.ToString() );
      return mapper.Model;
    }

    [Test]
    public void testEmptyClass() {
      this.mapAndCompare(
        @"
10 CLASS.
      ",
        @"
- CLASS
      "
      );
    }

    [Test]
    public void testClassWithOnlyFiller() {
      this.mapAndCompare(
        @"
10 CLASS.
   12 FILLER.
      ",
        @"
- CLASS
      "
      );
    }

    [Test]
    public void testClassWithSingleIntegerProperty() {
      this.mapAndCompare(
        @"
10 CLASS.
   12 PROPERTY PIC 9.
        ",
        @"
- CLASS
  - PROPERTY : integer(1)
      ");
    }

    [Test]
    public void testClassWithSingleSignedIntegerProperty() {
      this.mapAndCompare(
        @"
10 CLASS.
   12 PROPERTY PIC S9.
        ",
        @"
- CLASS
  - PROPERTY : signed integer(2)
      ");
    }

    [Test]
    public void testClassWithSingleSignedFloatProperty() {
      this.mapAndCompare(
        @"
10 CLASS.
   12 PROPERTY PIC S9.9.
        ",
        @"
- CLASS
  - PROPERTY : signed float(2,1)
      ");
    }

    [Test]
    public void testClassWithSingleStringProperty() {
      this.mapAndCompare(
        @"
10 CLASS.
   12 PROPERTY PIC XXX.
        ",
        @"
- CLASS
  - PROPERTY : string(3)
      ");
    }

    [Test]
    public void testClassWithOneAssociationToEmptyClass() {
      this.mapAndCompare(
        @"
10 CLASS.
   12 SUBCLASS.
        ",
        @"
- SUBCLASS
- CLASS
  -> SUBCLASS
      ");
    }

    [Test]
    public void testClassWithNestedAssociationsToClassWithOnlyFillers() {
      this.mapAndCompare(
        @"
10 X.
   12 Y1.
      13 Z. 
         14 FILLER.
         14 FILLER.
   12 Y2.
      14 FILLER.
        ",
        @"
- Z
- Y1
  -> Z
- Y2
- X
  -> Y1
  -> Y2
       ");
    }

    [Test]
    public void testClassWithTwoAssociationsToClassWithOnlyFillers() {
      this.mapAndCompare(
        @"
10 CLASS.
   12 SUBCLASS1.
      14 FILLER.
   12 SUBCLASS2.
      14 FILLER.
        ",
        @"
- SUBCLASS1
- SUBCLASS2
- CLASS
  -> SUBCLASS1
  -> SUBCLASS2
       ");
    }

    [Test]
    public void testClassWithAssociation100Times() {
      this.mapAndCompare(
        @"
10 CLASS.
  20 MANY OCCURS 100 TIMES.
        ",
        @"
- MANY
- CLASS
  -> MANY[100]
      ");
    }

    [Test]
    public void testClassWithAssociation0To100Times() {
      this.mapAndCompare(
        @"
10 CLASS.
  20 MANY OCCURS 0 TO 100 TIMES.
        ",
        @"
- MANY
- CLASS
  -> MANY[0..100]
      ");
    }

    [Test]
    public void testClassWithAssociation0To100TimesWithDependency() {
      this.mapAndCompare(
        @"
10 CLASS.
  20 MANY OCCURS 0 TO 100 TIMES DEPENDING ON SOMETHING.
        ",
        @"
- MANY
- CLASS
  -> MANY[0..100](SOMETHING)
      ");
    }

    [Test]
    public void testClassWithTwiceRedefinedProperty() {
      this.mapAndCompare(
        @"
10 CLASS.
  20 DATA PIC X(100).
  20 DATA1 REDEFINES DATA.
     30 NUMBERS PIC 9.
  20 DATA2 REDEFINES DATA.
     30 CHARACTERS PIC A.
        ",
        @"
- DATA1 : DATA
  - NUMBERS : integer(1)
- DATA2 : DATA
  - CHARACTERS : char
- DATA
- CLASS
  -> DATA
      ");
    }
    
  }
}
