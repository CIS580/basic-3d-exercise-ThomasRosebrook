using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Basic3DExample
{
    public class Triangle
    {
        VertexPositionColor[] vertices;

        BasicEffect effect;
        Game game;

        public Triangle(Game game)
        {
            this.game = game;
            InitializeVertices();
            InitializeEffect();
        }

        void InitializeVertices()
        {
            vertices = new VertexPositionColor[3];
            vertices[0].Position = new Vector3(0, 1, 0);
            vertices[0].Color = Color.Red;

            vertices[1].Position = new Vector3(1, 1, 0);
            vertices[1].Color = Color.Green;

            vertices[2].Position = new Vector3(1, 0, 0);
            vertices[2].Color = Color.Blue;
        }

        void InitializeEffect()
        {
            effect = new BasicEffect(game.GraphicsDevice);
            effect.World = Matrix.Identity;
            effect.View = Matrix.CreateLookAt(new Vector3(0,0,4), new Vector3(0,0,0), Vector3.Up);
            effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, game.GraphicsDevice.Viewport.AspectRatio, 0.1f, 100.0f);
            effect.VertexColorEnabled = true;
        }

        public void Update(GameTime gameTime)
        {
            float angle = (float)gameTime.TotalGameTime.TotalSeconds;
            effect.World = Matrix.CreateRotationY(angle);
        }

        public void Draw()
        {
            RasterizerState oldState = game.GraphicsDevice.RasterizerState;

            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;
            game.GraphicsDevice.RasterizerState = rasterizerState;

            effect.CurrentTechnique.Passes[0].Apply();
            game.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vertices, 0, 1);

            game.GraphicsDevice.RasterizerState = oldState;
        }
    }
}
