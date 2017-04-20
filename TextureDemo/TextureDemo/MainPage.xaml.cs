using System.Reflection;
using ThinkGeo.MapSuite.Core;
using ThinkGeo.MapSuite.FormsEdition;
using Xamarin.Forms;

namespace TextureDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MapView mapView = new MapView();
            Content = mapView;

            mapView.MapUnit = GeographyUnit.DecimalDegree;
            GeoImage textureSource = new GeoImage(typeof(MainPage).GetTypeInfo().Assembly.GetManifestResourceStream("TextureDemo.Images.texture.png"));
            GeoTextureBrush textureBrush = new GeoTextureBrush(textureSource);

            InMemoryFeatureLayer layer = new InMemoryFeatureLayer();
            layer.InternalFeatures.Add(new Feature(new EllipseShape(new PointShape(0, 0), 60)));
            layer.ZoomLevelSet.ZoomLevel01.DefaultAreaStyle = AreaStyles.County2;
            layer.ZoomLevelSet.ZoomLevel01.DefaultAreaStyle.Advanced.FillCustomBrush = textureBrush;
            layer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            LayerOverlay layerOverlay = new LayerOverlay();
            layerOverlay.Layers.Add(layer);
            mapView.Overlays.Add(layerOverlay);

            mapView.CurrentExtent = new RectangleShape(-180, 90, 180, -90);
        }
    }
}
