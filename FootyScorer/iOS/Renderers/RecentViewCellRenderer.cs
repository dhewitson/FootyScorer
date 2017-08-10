using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using FootyScorer.UI.Controls;

[assembly: ExportRenderer(typeof(RecentViewCell), typeof(FootyScorer.iOS.Renderers.RecentViewCellRenderer))]

namespace FootyScorer.iOS.Renderers
{
    public class RecentViewCellRenderer : ViewCellRenderer
    {
        /// <summary>
        /// Gets the cell.
        /// </summary>
        /// <returns>The cell.</returns>
        /// <param name="item">Item.</param>
        /// <param name="reusableCell">Reusable cell.</param>
        /// <param name="tv">Tv.</param>
        public override UIKit.UITableViewCell GetCell(Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            cell.SeparatorInset = UIKit.UIEdgeInsets.Zero;

            return cell;
        }
    }
}
