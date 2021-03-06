using System;
using Mono.Addins;
using Cairo;

namespace Pinta.Core
{
	/// <summary>
	/// The base class for all brushes.
	/// </summary>
	[TypeExtensionPoint]
	public abstract class BasePaintBrush
	{
		private static Random random = new Random ();

		/// <summary>
		/// The name of the brush.
		/// </summary>
		public abstract string Name { get; }

		/// <summary>
		/// Priority value for ordering brushes. If the priority is zero, then
		/// alphabetical ordering is used.
		/// </summary>
		public virtual int Priority {
			get { return 0; }
		}

		/// <summary>
		/// Random number generator. This can be used to implement brushes with
		/// random effects.
		/// </summary>
		public Random Random {
			get { return random; }
		}

		/// <summary>
		/// Used to multiply the alpha value of the stroke color by a
		/// constant factor.
		/// </summary>
		public virtual double StrokeAlphaMultiplier {
			get { return 1; }
		}

		public virtual void DoMouseUp ()
		{
			OnMouseUp ();
		}

		public virtual void DoMouseDown ()
		{
			OnMouseDown ();
		}

		public virtual Gdk.Rectangle DoMouseMove (Context g, Color strokeColor, ImageSurface surface,
		                                          int x, int y, int lastX, int lastY)
		{
			return OnMouseMove (g, strokeColor, surface, x, y, lastX, lastY);
		}

		/// <summary>
		/// Event handler called when the mouse is released.
		/// </summary>
		protected virtual void OnMouseUp ()
		{
		}

		/// <summary>
		/// Event handler called when the mouse is pressed down.
		/// </summary>
		protected virtual void OnMouseDown ()
		{
		}

		/// <summary>
		/// Event handler called when the mouse is moved. This method is where
		/// the brush should perform its drawing.
		/// </summary>
		/// <param name="g">The current Cairo drawing context.</param>
		/// <param name="strokeColor">The current stroke color.</param>
		/// <param name="surface">Image surface to draw on.</param>
		/// <param name="x">The current x coordinate of the mouse.</param>
		/// <param name="y">The current y coordinate of the mouse.</param>
		/// <param name="lastX">The previous x coordinate of the mouse.</param>
		/// <param name="lastY">The previous y coordinate of the mouse.</param>
		/// <returns>A rectangle containing the area of the canvas that should be redrawn.</returns>
		protected abstract Gdk.Rectangle OnMouseMove (Context g, Color strokeColor, ImageSurface surface,
		                                              int x, int y, int lastX, int lastY);
	}
}