using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders.GameObjects
{
    public class Player
    {
        private Texture2D _texture;
        private Vector2 _position;
        private float _speed = 250f;
        private float _scale = 0.5f;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _texture,
                _position,
                null, // origin rectangule
                Microsoft.Xna.Framework.Color.White,
                0f, // Rotação
                Vector2.Zero, // origin point
                _scale, // scale factor
                SpriteEffects.None,
                0f // depth layer
            );
        }

        public void LoadContent(ContentManager content)
        {
            try
            {
                _texture = content.Load<Texture2D>("UFO_1_Enlarged");
                Debug.WriteLine($"Textura carregada. Dimensões: {_texture.Width}x{_texture.Height}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao carregar textura: {ex.Message}");
            }

            _position = new Vector2(400, 500);
        }

        public void Update(GameTime gameTime)
        {
            // Obtain state from keyboard
            var keyboardState = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Move the player according to the key he pressed
            if (keyboardState.IsKeyDown(Keys.Left))
                _position.X -= _speed * deltaTime;
            if (keyboardState.IsKeyDown(Keys.Right))
                _position.X += _speed * deltaTime;

            // Make sure it's moving only within the screen size
            _position.X = MathHelper.Clamp(_position.X, 0, 800 - (_texture.Width * _scale));
        }
    }
}
