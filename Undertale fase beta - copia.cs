using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project2
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D pixel;

        Rectangle jugador;
        Rectangle celda;

        float velocidad = 250f;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            celda = new Rectangle(100, 50, 600, 400);

            jugador = new Rectangle(
                380,
                250,
                30,
                30
            );

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            pixel = new Texture2D(GraphicsDevice, 1, 1);

            pixel.SetData(new[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState teclado = Keyboard.GetState();

            float tiempo =
                (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (teclado.IsKeyDown(Keys.W))
                jugador.Y -= (int)(velocidad * tiempo);

            if (teclado.IsKeyDown(Keys.S))
                jugador.Y += (int)(velocidad * tiempo);

            if (teclado.IsKeyDown(Keys.A))
                jugador.X -= (int)(velocidad * tiempo);

            if (teclado.IsKeyDown(Keys.D))
                jugador.X += (int)(velocidad * tiempo);

            // No permitir salir de la celda

            if (jugador.Left < celda.Left)
                jugador.X = celda.Left;

            if (jugador.Right > celda.Right)
                jugador.X = celda.Right - jugador.Width;

            if (jugador.Top < celda.Top)
                jugador.Y = celda.Top;

            if (jugador.Bottom > celda.Bottom)
                jugador.Y = celda.Bottom - jugador.Height;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            // Borde de la celda
            DibujarBorde(celda, 4, Color.White);

            // Jugador rojo
            spriteBatch.Draw(
                pixel,
                jugador,
                Color.Red
            );

            spriteBatch.End();

            base.Draw(gameTime);
        }

        void DibujarBorde(
            Rectangle rectangulo,
            int grosor,
            Color color)
        {
            spriteBatch.Draw(
                pixel,
                new Rectangle(
                    rectangulo.Left,
                    rectangulo.Top,
                    rectangulo.Width,
                    grosor),
                color);

            spriteBatch.Draw(
                pixel,
                new Rectangle(
                    rectangulo.Left,
                    rectangulo.Bottom - grosor,
                    rectangulo.Width,
                    grosor),
                color);

            spriteBatch.Draw(
                pixel,
                new Rectangle(
                    rectangulo.Left,
                    rectangulo.Top,
                    grosor,
                    rectangulo.Height),
                color);

            spriteBatch.Draw(
                pixel,
                new Rectangle(
                    rectangulo.Right - grosor,
                    rectangulo.Top,
                    grosor,
                    rectangulo.Height),
                color);
        }
    }
}
