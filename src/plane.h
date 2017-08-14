#include <SDL.h>
#include <SDL_image.h>
#include <string>

class Plane {

public:
	Plane(SDL_Renderer* renderer,
				std::string name,
				int type,
				int health=100);

	~Plane();

	void render(int x, int y);
	int getWidth();
	int getHeight();

	void start_shooting();
	void stop_shooting();

private:
	int _width;
	int _height;
	SDL_Texture* _texture;
	SDL_Renderer* _renderer;

	int _health;
	bool _shooting = false;
};
