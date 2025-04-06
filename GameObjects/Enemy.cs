using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;


namespace SpaceInvaders.GameObjects
{
    public class Enemy
    {
        private Texture2D _texture;
        private Microsoft.Xna.Framework.Vector2 _position;
        private float _speed = 150f;
        private float _scale = 0.3f;
        private int _direction = 1; // 1 to right, -1 to left
        private bool _shouldMoveDown = false;
        private float _dropDistance = 1200f; // Distance it will drop when reach border

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _texture,
                _position,
                null,
                Microsoft.Xna.Framework.Color.White,
                0f, // rotation
                Microsoft.Xna.Framework.Vector2.Zero, // origin point
                _scale, // scale factor
                SpriteEffects.None,
                0f // depth layer
            );
        }

        public void LoadContent(ContentManager content)
        {
            try
            {
                _texture = content.Load<Texture2D>("Alien_1_Enlarged");
                Debug.WriteLine($"Textura carregada. Dimensões: {_texture.Width}x{_texture.Height}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao carregar textura: {ex.Message}");
            }

            _position = new Microsoft.Xna.Framework.Vector2(0, 50);
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Debug.WriteLine($"_position.X: {_position.X}\n_speed:{_speed}\n_position.Y:{_position.Y}");

            if (_shouldMoveDown)
            {
                _position.Y += _dropDistance * deltaTime; // Fall a few pixels
                _shouldMoveDown = false;
            }
            else
            {
                // Normal horizontal movement
                _position.X += _direction * _speed * deltaTime;
            }

            // Verify if enemy reached screen border
            if (IsScreenBorder())
            {

                _direction *= -1;
                _shouldMoveDown = true;
            }
        }

        /// <summary>
        /// Method to check if the enemy has reached the screen border
        /// </summary>
        /// <returns>True if border limits. False if not</returns>
        private bool IsScreenBorder()
        {
            return (_position.X >= 800 - (_texture.Width * _scale) && _direction > 0) ||
                           (_position.X <= 0 && _direction < 0);
        }
    }
}
