namespace AlphaMods.Renderer.Interfaces
{
    public interface IRenderer
    {
        delegate void Render();

        void Start();
        void AddLayer(IRenderLayer layer, LayerDepth layerDepth);
        void SetRoot(Render root);
        void RenderGame();
        void RenderMinimap();
    }
}