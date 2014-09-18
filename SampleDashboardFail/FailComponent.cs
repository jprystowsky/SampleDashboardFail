namespace SampleDashboardFail {
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Windows.Forms;

	using Aptify.Framework.Application;
	using Aptify.Framework.DigitalDashboard;

	public class FailComponent : UserControl, IDashboardComponent {
		#region Fields

		private Label countLabel;

		#endregion

		#region Constructors and Destructors

		public FailComponent() {
			this.Properties = new AptifyProperties();
		}

		#endregion

		#region Public Properties

		public long ID { get; private set; }
		public DashboardMode Mode { get; set; }
		public AptifyProperties Properties { get; private set; }
		public ComponentState State { get; set; }

		#endregion

		#region Properties

		protected AptifyApplication App { get; set; }
		protected IDashboardArea Area { get; set; }
		protected ComponentOrientation Orientation { get; set; }
		protected long PartId { get; set; }

		#endregion

		#region Public Methods and Operators

		public void Config(
			AptifyApplication ApplicationObject,
			IDashboardArea Area,
			long PartID,
			ComponentOrientation Orientation) {
			this.App = ApplicationObject;
			this.Area = Area;
			this.PartId = PartID;
			this.Orientation = Orientation;

			this.InitializeComponent();
			this.DoTheDew();
		}

		#endregion

		#region Methods

		private void DoTheDew() {
			// The label should have a value of "5"
			this.countLabel.Text = new[] { 1, 2, 3 }.Aggregate(-1, (n, m) => n + m).ToString(CultureInfo.InvariantCulture);
		}

		private void InitializeComponent() {
			this.SuspendLayout();

			this.Size = new Size(100, 100);

			this.countLabel = new Label { Location = new Point(10, 10), AutoSize = true };
			this.Controls.Add(this.countLabel);

			this.ResumeLayout();
		}

		#endregion
	}
}