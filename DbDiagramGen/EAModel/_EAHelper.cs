namespace DbDiagramGen
{
	public class EAHelper
	{
		public static string TranslateUMLDiagramtypes(string diagramType)
		{
			string eaDiagramType;
			switch (diagramType)
			{
				case "ActivityDiagram":
					eaDiagramType = "Activity";
					break;
				case "ClassDiagram":
					eaDiagramType = "Logical";
					break;
				case "DeploymentDiagram":
					eaDiagramType = "Deployment";
					break;
				case "ComponentDiagram":
					eaDiagramType = "Component";
					break;
				case "SequenceDiagram":
					eaDiagramType = "Sequence";
					break;
				case "StateMachineDiagram":
					eaDiagramType = "Statechart";
					break;
				case "UseCaseDiagram":
					eaDiagramType = "Use Case";
					break;
				case "CommunicationDiagram":
					eaDiagramType = "Collaboration";
					break;
				case "CompositeStructureDiagram":
					eaDiagramType = "CompositeStructure";
					break;
				case "InteractionOverviewDiagramram":
					eaDiagramType = "InteractionOverview";
					break;
				case "PackageDiagram":
					eaDiagramType = "Package";
					break;
				case "TimingDiagram":
					eaDiagramType = "Timing";
					break;
				case "ObjectDiagram":
					eaDiagramType = "Object";
					break;
				default:
					eaDiagramType = "Custom";
					break;
			}
			return eaDiagramType;
		}
	}
}
