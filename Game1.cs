using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace peleaparte1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        

        private Texture2D _demonio;
        private Texture2D _corazon;
        private Texture2D _pixel;

        // Formas de proyectiles
        private Texture2D _circulo;
        private Texture2D _triangulo;
        private Texture2D _estrella;
        private Texture2D _diamante;

       

        private Rectangle _jugador;
        private int _vidaJugador = 150;

       
        private int _vidaDemonio = 500;

        

        private Rectangle _arena;

        

        private float _velocidad = 250f;

        

        private class Proyectil
        {
            public Vector2 Posicion;
            public Vector2 Velocidad;

            public Texture2D Textura;

            public float Rotacion;
            public float VelocidadRotacion;

            public int Tamaño;

            public bool Activo = true;
        }

        private List<Proyectil> _proyectiles =
            new List<Proyectil>();

        

        // Cada fase dura bastante
        private float _tiempoAtaque = 0f;

        private float _duracionAtaque = 12f;

        // Controla cuándo cambia el patrón
        private float _tiempoPatron = 0f;

        private int _patronActual = 0;

        private float _intervaloPatron = 3f;

        

        private int _fase = 1;

        private float _multiplicadorVelocidad = 1f;

        

        private bool _turnoJugador = false;

        private bool _ataqueEnCurso = false;

        

        private float _punteroAtaque = 0f;

        private float _direccionPuntero = 1f;

        private KeyboardState _tecladoAnterior;

        

        private bool _gano = false;
        private bool _perdio = false;

        private Random _random = new Random();

       

        public Game1()
        {
            _graphics =
                new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 900;
            _graphics.PreferredBackBufferHeight = 700;
        }

        

        protected override void Initialize()
        {
            _arena = new Rectangle(
                200,
                300,
                500,
                300
            );

            _jugador = new Rectangle(
                438,
                438,
                24,
                24
            );

            base.Initialize();
        }

        

        protected override void LoadContent()
        {
            _spriteBatch =
                new SpriteBatch(GraphicsDevice);

            _demonio =
                Content.Load<Texture2D>("unnamed");

            _corazon =
                Content.Load<Texture2D>("protagonista");

            _pixel =
                new Texture2D(
                    GraphicsDevice,
                    1,
                    1
                );

            _pixel.SetData(
                new[] { Color.White }
            );

            // Crear formas
            _circulo =
                CrearCirculo(32);

            _triangulo =
                CrearTriangulo(36);

            _estrella =
                CrearEstrella(40);

            _diamante =
                CrearDiamante(34);

            IniciarAtaqueDemonio();
        }

       
        private Texture2D CrearCirculo(int tamaño)
        {
            Texture2D textura =
                new Texture2D(
                    GraphicsDevice,
                    tamaño,
                    tamaño
                );

            Color[] datos =
                new Color[tamaño * tamaño];

            float centro = tamaño / 2f;
            float radio = tamaño / 2f;

            for (int y = 0; y < tamaño; y++)
            {
                for (int x = 0; x < tamaño; x++)
                {
                    float dx = x - centro;
                    float dy = y - centro;

                    float distancia =
                        (float)Math.Sqrt(
                            dx * dx + dy * dy
                        );

                    datos[y * tamaño + x] =
                        distancia <= radio
                        ? Color.White
                        : Color.Transparent;
                }
            }

            textura.SetData(datos);

            return textura;
        }

       

        private Texture2D CrearTriangulo(int tamaño)
        {
            Texture2D textura =
                new Texture2D(
                    GraphicsDevice,
                    tamaño,
                    tamaño
                );

            Color[] datos =
                new Color[tamaño * tamaño];

            Vector2 A =
                new Vector2(
                    tamaño / 2f,
                    2
                );

            Vector2 B =
                new Vector2(
                    2,
                    tamaño - 2
                );

            Vector2 C =
                new Vector2(
                    tamaño - 2,
                    tamaño - 2
                );

            for (int y = 0; y < tamaño; y++)
            {
                for (int x = 0; x < tamaño; x++)
                {
                    Vector2 punto =
                        new Vector2(x, y);

                    datos[y * tamaño + x] =
                        DentroTriangulo(
                            punto,
                            A,
                            B,
                            C
                        )
                        ? Color.White
                        : Color.Transparent;
                }
            }

            textura.SetData(datos);

            return textura;
        }

        private bool DentroTriangulo(
            Vector2 p,
            Vector2 a,
            Vector2 b,
            Vector2 c)
        {
            float d1 =
                ProductoCruz(p, a, b);

            float d2 =
                ProductoCruz(p, b, c);

            float d3 =
                ProductoCruz(p, c, a);

            bool negativo =
                d1 < 0 ||
                d2 < 0 ||
                d3 < 0;

            bool positivo =
                d1 > 0 ||
                d2 > 0 ||
                d3 > 0;

            return !(negativo && positivo);
        }

        private float ProductoCruz(
            Vector2 p,
            Vector2 a,
            Vector2 b)
        {
            return
                (p.X - b.X) *
                (a.Y - b.Y)
                -
                (a.X - b.X) *
                (p.Y - b.Y);
        }

        

        private Texture2D CrearDiamante(int tamaño)
        {
            Texture2D textura =
                new Texture2D(
                    GraphicsDevice,
                    tamaño,
                    tamaño
                );

            Color[] datos =
                new Color[tamaño * tamaño];

            float centro =
                tamaño / 2f;

            for (int y = 0; y < tamaño; y++)
            {
                for (int x = 0; x < tamaño; x++)
                {
                    float distancia =
                        Math.Abs(x - centro) +
                        Math.Abs(y - centro);

                    datos[y * tamaño + x] =
                        distancia <= centro
                        ? Color.White
                        : Color.Transparent;
                }
            }

            textura.SetData(datos);

            return textura;
        }

        

        private Texture2D CrearEstrella(int tamaño)
        {
            Texture2D textura =
                new Texture2D(
                    GraphicsDevice,
                    tamaño,
                    tamaño
                );

            Color[] datos =
                new Color[tamaño * tamaño];

            float centro =
                tamaño / 2f;

            float radioExterior =
                tamaño / 2f - 2;

            float radioInterior =
                radioExterior * 0.42f;

            for (int y = 0; y < tamaño; y++)
            {
                for (int x = 0; x < tamaño; x++)
                {
                    float dx = x - centro;
                    float dy = y - centro;

                    float distancia =
                        (float)Math.Sqrt(
                            dx * dx + dy * dy
                        );

                    float angulo =
                        (float)Math.Atan2(dy, dx);

                    float sector =
                        (angulo +
                        MathHelper.PiOver2)
                        %
                        MathHelper.TwoPi;

                    if (sector < 0)
                        sector += MathHelper.TwoPi;

                    float local =
                        sector %
                        (MathHelper.TwoPi / 5f);

                    float limite =
                        radioInterior +
                        (radioExterior -
                        radioInterior) *
                        (
                            1 -
                            Math.Abs(
                                local -
                                MathHelper.Pi / 5f
                            ) /
                            (MathHelper.Pi / 5f)
                        );

                    datos[y * tamaño + x] =
                        distancia <= limite
                        ? Color.White
                        : Color.Transparent;
                }
            }

            textura.SetData(datos);

            return textura;
        }

        // =========================================================
        // UPDATE
        // =========================================================

        protected override void Update(GameTime gameTime)
        {
            KeyboardState teclado =
                Keyboard.GetState();

            if (teclado.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (_gano || _perdio)
            {
                return;
            }

            float tiempo =
                (float)gameTime
                    .ElapsedGameTime
                    .TotalSeconds;

            if (_turnoJugador)
            {
                ActualizarTurnoJugador(
                    teclado,
                    tiempo
                );
            }
            else
            {
                ActualizarAtaqueDemonio(
                    tiempo
                );

                MoverJugador(
                    teclado,
                    tiempo
                );
            }

            _tecladoAnterior =
                teclado;

            base.Update(gameTime);
        }

        // =========================================================
        // MOVIMIENTO DEL JUGADOR
        // =========================================================

        private void MoverJugador(
            KeyboardState teclado,
            float tiempo)
        {
            if (teclado.IsKeyDown(Keys.W))
            {
                _jugador.Y -=
                    (int)(_velocidad * tiempo);
            }

            if (teclado.IsKeyDown(Keys.S))
            {
                _jugador.Y +=
                    (int)(_velocidad * tiempo);
            }

            if (teclado.IsKeyDown(Keys.A))
            {
                _jugador.X -=
                    (int)(_velocidad * tiempo);
            }

            if (teclado.IsKeyDown(Keys.D))
            {
                _jugador.X +=
                    (int)(_velocidad * tiempo);
            }

            if (_jugador.Left < _arena.Left)
                _jugador.X = _arena.Left;

            if (_jugador.Right > _arena.Right)
                _jugador.X =
                    _arena.Right -
                    _jugador.Width;

            if (_jugador.Top < _arena.Top)
                _jugador.Y = _arena.Top;

            if (_jugador.Bottom > _arena.Bottom)
                _jugador.Y =
                    _arena.Bottom -
                    _jugador.Height;
        }

        

        private void IniciarAtaqueDemonio()
        {
            _turnoJugador = false;

            _ataqueEnCurso = true;

            _tiempoAtaque = 0f;

            _tiempoPatron = 0f;

            _patronActual = 0;

            _proyectiles.Clear();

            // Cada fase dura más
            if (_fase == 1)
                _duracionAtaque = 12f;

            if (_fase == 2)
                _duracionAtaque = 14f;

            if (_fase == 3)
                _duracionAtaque = 16f;

            EjecutarPatron();
        }

       

        private void EjecutarPatron()
        {
            if (_fase == 1)
            {
                if (_patronActual == 0)
                    Fase1_LluviaCirculos();

                else if (_patronActual == 1)
                    Fase1_DiamantesLaterales();

                else if (_patronActual == 2)
                    Fase1_CirculosRapidos();
            }

            else if (_fase == 2)
            {
                if (_patronActual == 0)
                    Fase2_EspiralEstrellas();

                else if (_patronActual == 1)
                    Fase2_TriangulosArriba();

                else if (_patronActual == 2)
                    Fase2_Cruz();

                else if (_patronActual == 3)
                    Fase2_LluviaDiamantes();
            }

            else if (_fase == 3)
            {
                if (_patronActual == 0)
                    Fase3_Objetivo();

                else if (_patronActual == 1)
                    Fase3_ArribaAbajo();

                else if (_patronActual == 2)
                    Fase3_Estrellas();

                else if (_patronActual == 3)
                    Fase3_Combinado();
            }
        }

        

        private void Fase1_LluviaCirculos()
        {
            for (int i = 0; i < 8; i++)
            {
                float x =
                    _arena.Left +
                    _random.Next(
                        20,
                        _arena.Width - 20
                    );

                float y =
                    _arena.Top -
                    40;

                float velocidad =
                    (150 +
                    _random.Next(0, 80))
                    *
                    _multiplicadorVelocidad;

                _proyectiles.Add(
                    new Proyectil
                    {
                        Posicion =
                            new Vector2(x, y),

                        Velocidad =
                            new Vector2(
                                0,
                                velocidad
                            ),

                        Textura =
                            _circulo,

                        Tamaño = 28,

                        Rotacion = 0,

                        VelocidadRotacion = 1f
                    }
                );
            }
        }

       

        private void Fase1_DiamantesLaterales()
        {
            for (int i = 0; i < 6; i++)
            {
                float y =
                    _arena.Top +
                    30 +
                    i * 48;

                float velocidad =
                    180f *
                    _multiplicadorVelocidad;

                _proyectiles.Add(
                    new Proyectil
                    {
                        Posicion =
                            new Vector2(
                                _arena.Left - 35,
                                y
                            ),

                        Velocidad =
                            new Vector2(
                                velocidad,
                                0
                            ),

                        Textura =
                            _diamante,

                        Tamaño = 30,

                        Rotacion = 0,

                        VelocidadRotacion = 4f
                    }
                );

                _proyectiles.Add(
                    new Proyectil
                    {
                        Posicion =
                            new Vector2(
                                _arena.Right + 35,
                                y
                            ),

                        Velocidad =
                            new Vector2(
                                -velocidad,
                                0
                            ),

                        Textura =
                            _diamante,

                        Tamaño = 30,

                        Rotacion = 0,

                        VelocidadRotacion = -4f
                    }
                );
            }
        }

        

        private void Fase1_CirculosRapidos()
        {
            for (int i = 0; i < 12; i++)
            {
                float x =
                    _arena.Left +
                    _random.Next(
                        0,
                        _arena.Width
                    );

                float velocidad =
                    (250 +
                    _random.Next(0, 100))
                    *
                    _multiplicadorVelocidad;

                _proyectiles.Add(
                    new Proyectil
                    {
                        Posicion =
                            new Vector2(
                                x,
                                _arena.Bottom + 30
                            ),

                        Velocidad =
                            new Vector2(
                                0,
                                -velocidad
                            ),

                        Textura =
                            _circulo,

                        Tamaño = 22,

                        Rotacion = 0,

                        VelocidadRotacion = 2f
                    }
                );
            }
        }

        

        private void Fase2_EspiralEstrellas()
        {
            Vector2 centro =
                new Vector2(
                    _arena.Center.X,
                    _arena.Center.Y
                );

            for (int i = 0; i < 10; i++)
            {
                float angulo =
                    MathHelper.TwoPi *
                    i / 10f;

                Vector2 direccion =
                    new Vector2(
                        (float)Math.Cos(angulo),
                        (float)Math.Sin(angulo)
                    );

                float velocidad =
                    130f *
                    _multiplicadorVelocidad;

                _proyectiles.Add(
                    new Proyectil
                    {
                        Posicion = centro,

                        Velocidad =
                            direccion *
                            velocidad,

                        Textura =
                            _estrella,

                        Tamaño = 34,

                        Rotacion = angulo,

                        VelocidadRotacion = 5f
                    }
                );
            }
        }

        

        private void Fase2_TriangulosArriba()
        {
            for (int i = 0; i < 8; i++)
            {
                float x =
                    _arena.Left +
                    30 +
                    i * 60;

                float velocidad =
                    200f *
                    _multiplicadorVelocidad;

                _proyectiles.Add(
                    new Proyectil
                    {
                        Posicion =
                            new Vector2(
                                x,
                                _arena.Top - 40
                            ),

                        Velocidad =
                            new Vector2(
                                0,
                                velocidad
                            ),

                        Textura =
                            _triangulo,

                        Tamaño = 34,

                        Rotacion = 0,

                        VelocidadRotacion = 1f
                    }
                );
            }
        }

       

        private void Fase2_Cruz()
        {
            Vector2 centro =
                new Vector2(
                    _arena.Center.X,
                    _arena.Center.Y
                );

            Vector2[] direcciones =
            {
                new Vector2(1, 0),
                new Vector2(-1, 0),
                new Vector2(0, 1),
                new Vector2(0, -1)
            };

            foreach (Vector2 direccion
                     in direcciones)
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector2 posicion =
                        centro -
                        direccion *
                        (i * 35);

                    _proyectiles.Add(
                        new Proyectil
                        {
                            Posicion =
                                posicion,

                            Velocidad =
                                direccion *
                                170f *
                                _multiplicadorVelocidad,

                            Textura =
                                _diamante,

                            Tamaño = 28,

                            Rotacion = 0,

                            VelocidadRotacion = 5f
                        }
                    );
                }
            }
        }

        

        private void Fase2_LluviaDiamantes()
        {
            for (int i = 0; i < 10; i++)
            {
                float x =
                    _arena.Left +
                    _random.Next(
                        0,
                        _arena.Width
                    );

                float velocidad =
                    180f *
                    _multiplicadorVelocidad;

                _proyectiles.Add(
                    new Proyectil
                    {
                        Posicion =
                            new Vector2(
                                x,
                                _arena.Top - 30
                            ),

                        Velocidad =
                            new Vector2(
                                0,
                                velocidad
                            ),

                        Textura =
                            _diamante,

                        Tamaño = 25,

                        Rotacion = 0,

                        VelocidadRotacion = 6f
                    }
                );
            }
        }

        

        private void Fase3_Objetivo()
        {
            for (int i = 0; i < 8; i++)
            {
                bool izquierda =
                    i % 2 == 0;

                float y =
                    _arena.Top +
                    20 +
                    _random.Next(
                        0,
                        _arena.Height - 40
                    );

                Vector2 posicion;

                if (izquierda)
                {
                    posicion =
                        new Vector2(
                            _arena.Left - 40,
                            y
                        );
                }
                else
                {
                    posicion =
                        new Vector2(
                            _arena.Right + 40,
                            y
                        );
                }

                Vector2 objetivo =
                    new Vector2(
                        _jugador.Center.X,
                        _jugador.Center.Y
                    );

                Vector2 direccion =
                    objetivo -
                    posicion;

                if (direccion != Vector2.Zero)
                    direccion.Normalize();

                float velocidad =
                    210f *
                    _multiplicadorVelocidad;

                float rotacion =
                    (float)Math.Atan2(
                        direccion.Y,
                        direccion.X
                    )
                    +
                    MathHelper.PiOver2;

                _proyectiles.Add(
                    new Proyectil
                    {
                        Posicion =
                            posicion,

                        Velocidad =
                            direccion *
                            velocidad,

                        Textura =
                            _triangulo,

                        Tamaño = 34,

                        Rotacion =
                            rotacion,

                        VelocidadRotacion = 0
                    }
                );
            }
        }

        

        private void Fase3_ArribaAbajo()
        {
            for (int i = 0; i < 7; i++)
            {
                float x =
                    _arena.Left +
                    35 +
                    i * 70;

                float velocidad =
                    220f *
                    _multiplicadorVelocidad;

                _proyectiles.Add(
                    new Proyectil
                    {
                        Posicion =
                            new Vector2(
                                x,
                                _arena.Top - 35
                            ),

                        Velocidad =
                            new Vector2(
                                0,
                                velocidad
                            ),

                        Textura =
                            _diamante,

                        Tamaño = 30,

                        Rotacion = 0,

                        VelocidadRotacion = 5f
                    }
                );

                _proyectiles.Add(
                    new Proyectil
                    {
                        Posicion =
                            new Vector2(
                                x,
                                _arena.Bottom + 35
                            ),

                        Velocidad =
                            new Vector2(
                                0,
                                -velocidad
                            ),

                        Textura =
                            _diamante,

                        Tamaño = 30,

                        Rotacion = 0,

                        VelocidadRotacion = -5f
                    }
                );
            }
        }

        

        private void Fase3_Estrellas()
        {
            Vector2 centro =
                new Vector2(
                    _arena.Center.X,
                    _arena.Center.Y
                );

            for (int i = 0; i < 16; i++)
            {
                float angulo =
                    MathHelper.TwoPi *
                    i / 16f;

                Vector2 direccion =
                    new Vector2(
                        (float)Math.Cos(angulo),
                        (float)Math.Sin(angulo)
                    );

                _proyectiles.Add(
                    new Proyectil
                    {
                        Posicion =
                            centro,

                        Velocidad =
                            direccion *
                            200f *
                            _multiplicadorVelocidad,

                        Textura =
                            _estrella,

                        Tamaño = 32,

                        Rotacion =
                            angulo,

                        VelocidadRotacion = 7f
                    }
                );
            }
        }

       
        private void Fase3_Combinado()
        {
            // Círculos desde la izquierda
            for (int i = 0; i < 5; i++)
            {
                float y =
                    _arena.Top +
                    30 +
                    i * 55;

                _proyectiles.Add(
                    new Proyectil
                    {
                        Posicion =
                            new Vector2(
                                _arena.Left - 30,
                                y
                            ),

                        Velocidad =
                            new Vector2(
                                230f *
                                _multiplicadorVelocidad,
                                0
                            ),

                        Textura =
                            _circulo,

                        Tamaño = 24,

                        Rotacion = 0,

                        VelocidadRotacion = 3f
                    }
                );
            }

            // Triángulos desde la derecha
            for (int i = 0; i < 5; i++)
            {
                float y =
                    _arena.Top +
                    55 +
                    i * 55;

                _proyectiles.Add(
                    new Proyectil
                    {
                        Posicion =
                            new Vector2(
                                _arena.Right + 30,
                                y
                            ),

                        Velocidad =
                            new Vector2(
                                -230f *
                                _multiplicadorVelocidad,
                                0
                            ),

                        Textura =
                            _triangulo,

                        Tamaño = 30,

                        Rotacion =
                            MathHelper.Pi,

                        VelocidadRotacion = -3f
                    }
                );
            }

            // Estrellas desde el centro
            Vector2 centro =
                new Vector2(
                    _arena.Center.X,
                    _arena.Center.Y
                );

            for (int i = 0; i < 8; i++)
            {
                float angulo =
                    MathHelper.TwoPi *
                    i / 8f;

                Vector2 direccion =
                    new Vector2(
                        (float)Math.Cos(angulo),
                        (float)Math.Sin(angulo)
                    );

                _proyectiles.Add(
                    new Proyectil
                    {
                        Posicion =
                            centro,

                        Velocidad =
                            direccion *
                            150f *
                            _multiplicadorVelocidad,

                        Textura =
                            _estrella,

                        Tamaño = 30,

                        Rotacion = angulo,

                        VelocidadRotacion = 8f
                    }
                );
            }
        }

        

        private void ActualizarAtaqueDemonio(
            float tiempo)
        {
            _tiempoAtaque += tiempo;
            _tiempoPatron += tiempo;

           

            if (_tiempoPatron >= _intervaloPatron)
            {
                _tiempoPatron = 0f;

                _patronActual++;

                int cantidadPatrones;

                if (_fase == 1)
                    cantidadPatrones = 3;

                else if (_fase == 2)
                    cantidadPatrones = 4;

                else
                    cantidadPatrones = 4;

                if (_patronActual >= cantidadPatrones)
                {
                    _patronActual = 0;
                }

                EjecutarPatron();
            }

            

            foreach (
                Proyectil proyectil
                in _proyectiles
            )
            {
                if (!proyectil.Activo)
                    continue;

                proyectil.Posicion +=
                    proyectil.Velocidad *
                    tiempo;

                proyectil.Rotacion +=
                    proyectil.VelocidadRotacion *
                    tiempo;

                Rectangle rect =
                    ObtenerRectanguloProyectil(
                        proyectil
                    );

               

                if (rect.Intersects(_jugador))
                {
                    _vidaJugador -= 15;

                    proyectil.Activo = false;

                    if (_vidaJugador <= 0)
                    {
                        _vidaJugador = 0;

                        _perdio = true;

                        return;
                    }
                }

                

                if (
                    proyectil.Posicion.X <
                    _arena.Left - 100 ||

                    proyectil.Posicion.X >
                    _arena.Right + 100 ||

                    proyectil.Posicion.Y <
                    _arena.Top - 100 ||

                    proyectil.Posicion.Y >
                    _arena.Bottom + 100
                )
                {
                    proyectil.Activo = false;
                }
            }

            

            if (_tiempoAtaque >= _duracionAtaque)
            {
                _proyectiles.Clear();

                _turnoJugador = true;

                _ataqueEnCurso = false;

                _punteroAtaque = 0f;

                _direccionPuntero = 1f;
            }
        }

        

        private Rectangle ObtenerRectanguloProyectil(
            Proyectil proyectil)
        {
            int tamaño =
                proyectil.Tamaño;

            return new Rectangle(
                (int)proyectil.Posicion.X -
                tamaño / 2,

                (int)proyectil.Posicion.Y -
                tamaño / 2,

                tamaño,
                tamaño
            );
        }


        private void ActualizarTurnoJugador(
            KeyboardState teclado,
            float tiempo)
        {
            _punteroAtaque +=
                _direccionPuntero *
                tiempo *
                1.5f;

            if (_punteroAtaque >= 1)
            {
                _punteroAtaque = 1;

                _direccionPuntero = -1;
            }

            if (_punteroAtaque <= 0)
            {
                _punteroAtaque = 0;

                _direccionPuntero = 1;
            }

            if (
                teclado.IsKeyDown(Keys.Enter) &&
                !_tecladoAnterior.IsKeyDown(Keys.Enter)
            )
            {
                RealizarAtaque();
            }
        }

        

        private void RealizarAtaque()
        {
            if (!_turnoJugador)
            {
                return;
            }

            _turnoJugador = false;

            float distanciaCentro =
                Math.Abs(
                    _punteroAtaque - 0.5f
                );

            int daño;

            string resultado;

            // CRÍTICO
            if (distanciaCentro < 0.08f)
            {
                daño = 80;

                resultado = "CRITICO";
            }

            // NORMAL
            else if (distanciaCentro < 0.25f)
            {
                daño = 40;

                resultado = "NORMAL";
            }

            // LEVE
            else
            {
                daño = 20;

                resultado = "LEVE";
            }

            _vidaDemonio -= daño;

            if (_vidaDemonio <= 0)
            {
                _vidaDemonio = 0;

                _gano = true;

                return;
            }

            

            _fase++;

            if (_fase > 3)
            {
                _fase = 1;

                // Cada ciclo se vuelve más difícil
                _multiplicadorVelocidad += 0.25f;
            }

            IniciarAtaqueDemonio();
        }

        

        protected override void Draw(
            GameTime gameTime)
        {
            GraphicsDevice.Clear(
                Color.Black
            );

            _spriteBatch.Begin();

            

            _spriteBatch.Draw(
                _demonio,

                new Rectangle(
                    350,
                    40,
                    200,
                    200
                ),

                Color.White
            );

           

            _spriteBatch.Draw(
                _pixel,

                new Rectangle(
                    300,
                    250,
                    300,
                    20
                ),

                Color.White
            );

            _spriteBatch.Draw(
                _pixel,

                new Rectangle(
                    300,
                    250,
                    (_vidaDemonio * 300) / 500,
                    20
                ),

                Color.Red
            );

            

            _spriteBatch.Draw(
                _pixel,
                _arena,
                Color.White
            );

            _spriteBatch.Draw(
                _pixel,

                new Rectangle(
                    _arena.X + 4,
                    _arena.Y + 4,
                    _arena.Width - 8,
                    _arena.Height - 8
                ),

                Color.Black
            );

            

            foreach (
                Proyectil proyectil
                in _proyectiles
            )
            {
                if (!proyectil.Activo)
                    continue;

                Rectangle destino =
                    ObtenerRectanguloProyectil(
                        proyectil
                    );

                _spriteBatch.Draw(
                    proyectil.Textura,
                    destino,
                    null,
                    Color.Red,
                    proyectil.Rotacion,
                    new Vector2(
                        proyectil.Textura.Width / 2f,
                        proyectil.Textura.Height / 2f
                    ),
                    SpriteEffects.None,
                    0f
                );
            }

            

            _spriteBatch.Draw(
                _corazon,
                _jugador,
                Color.White
            );

            

            _spriteBatch.Draw(
                _pixel,

                new Rectangle(
                    200,
                    620,
                    300,
                    25
                ),

                Color.White
            );

            _spriteBatch.Draw(
                _pixel,

                new Rectangle(
                    200,
                    620,
                    _vidaJugador * 2,
                    25
                ),

                Color.Red
            );

           

            if (_turnoJugador)
            {
                DibujarBarraAtaque();
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

      

        private void DibujarBarraAtaque()
        {
            int x = 300;
            int y = 560;

            int ancho = 300;
            int alto = 25;

            // Fondo
            _spriteBatch.Draw(
                _pixel,

                new Rectangle(
                    x,
                    y,
                    ancho,
                    alto
                ),

                Color.White
            );

            // Zona crítica
            _spriteBatch.Draw(
                _pixel,

                new Rectangle(
                    x + 126,
                    y + 4,
                    48,
                    17
                ),

                Color.Red
            );

            // Indicador
            int posicion =
                x +
                (int)(
                    _punteroAtaque *
                    ancho
                );

            _spriteBatch.Draw(
                _pixel,

                new Rectangle(
                    posicion - 3,
                    y - 8,
                    6,
                    41
                ),

                Color.Yellow
            );
        }
    }
}
