using System.Collections.Generic;
using System.Windows;
using Fody;

namespace Bindables.Fody
{
	public class ModuleWeaver: BaseModuleWeaver
	{
		public override void Execute()
		{
			DependencyPropertyWeaver dependencyPropertyWeaver = new DependencyPropertyWeaver(
				ModuleDefinition,
				typeof(PropertyChangedCallback),
				typeof(CoerceValueCallback),
				typeof(FrameworkPropertyMetadata),
				typeof(FrameworkPropertyMetadataOptions),
				typeof(DependencyObject),
				typeof(DependencyProperty),
				typeof(DependencyPropertyChangedEventArgs),
				typeof(PropertyMetadata),
				typeof(DependencyPropertyKey));

			AttachedPropertyWeaver attachedPropertyWeaver = new AttachedPropertyWeaver(
				ModuleDefinition,
				typeof(PropertyChangedCallback),
				typeof(CoerceValueCallback),
				typeof(FrameworkPropertyMetadata),
				typeof(FrameworkPropertyMetadataOptions),
				typeof(DependencyObject),
				typeof(DependencyProperty),
				typeof(DependencyPropertyChangedEventArgs),
				typeof(PropertyMetadata));

			dependencyPropertyWeaver.Execute();
			attachedPropertyWeaver.Execute();
		}

		public override IEnumerable<string> GetAssembliesForScanning()
		{
			yield break;
		}

		public override bool ShouldCleanReference => true;
	}
}