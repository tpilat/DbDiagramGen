﻿using TSF.UmlToolingFramework;

namespace TSF.UmlToolingFramework.UML.Diagrams {
  /// the representation of an element on a diagram
  public interface DiagramElement:UML.Extended.UMLItem {
    UML.Classes.Kernel.Element element   { get; set; }
    int                        xPosition { get; set; }
    int                        yPosition { get; set; }
    UML.Diagrams.Diagram diagram {get;}
    void setOrientation(bool vertical);
  }
}
