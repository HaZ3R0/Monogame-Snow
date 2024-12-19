using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snow
{
    public class ParticleSystem
    {
        List<Particle> particles = new List<Particle>();
        Texture2D texture;
        Random random = new Random();
        float windPower = 50;

        private void RemoveParticles(){
            for(int i = 0; i < particles.Count; i++){
                if(particles[i].Position.Y > 400){
                    particles.RemoveAt(i);
                    i--;
                }
            }
        }

        public ParticleSystem(Texture2D texture){
            this.texture = texture;
        }

        private void SpawnParticle(){
            if(random.Next(1,101) < 20){
                particles.Add(CreateParticle());
            }
        }

        private Particle CreateParticle(){
            int size = random.Next(1,20);
            float x = random.Next(0,800);
            Vector2 position = new Vector2(x,-20);

            return new Particle(size,Color.GhostWhite,
            position,texture);
        }

        public void Update(){
            foreach(Particle particle in particles){
                particle.Velocity = new Vector2(windPower*0.016f, 0);
                particle.Update();
            }
            SpawnParticle();
            RemoveParticles();
        }

        public void Draw(SpriteBatch spriteBatch){
            foreach(Particle particle in particles){
                particle.Draw(spriteBatch);
            }
        }
    }
}