﻿
using System;
using System.Collections.Generic;
using UML=TSF.UmlToolingFramework.UML;

namespace SchemaBuilderFramework
{
	/// <summary>
	/// Description of SchemaElement.
	/// </summary>
	public interface SchemaElement
	{
		string name {get;}
		UML.Classes.Kernel.Classifier sourceElement {get;set;}
		UML.Classes.Kernel.Classifier subsetElement {get;set;}
		Schema owner {get;set;}
		HashSet<SchemaProperty> schemaProperties {get;set;}
		HashSet<SchemaAssociation> schemaAssociations {get;set;}
		HashSet<SchemaLiteral> schemaLiterals {get;set;}
		UML.Classes.Kernel.Classifier createSubsetElement(UML.Classes.Kernel.Package destinationPackage);
		bool isShared {get;}
		
	}
}
