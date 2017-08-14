#include "plane.h"

Plane::Plane(SDL_Renderer* renderer,
						std::string name,
						int type,
						int health) {

	_renderer = renderer;
	_health = health;

	char *full_path = new char[100];
  sprintf(full_path, "assets/%s/Type_%d/plane.png", name.c_str(), type);

	auto loaded_surface = IMG_Load(full_path);
  if (!loaded_surface) {
		throw "cannot load plane image";
	}

	auto texture = SDL_CreateTextureFromSurface(renderer, loaded_surface);
	if (!texture) {
		throw "cannot create texture";
	}
	_texture = texture;
	_width = loaded_surface->w;
	_height = loaded_surface->h;


  SDL_FreeSurface(loaded_surface);
}

Plane::~Plane() {
	if (_renderer) {
		_renderer = nullptr;
	}

	if (_texture) {
		SDL_DestroyTexture(_texture);
		_texture = nullptr;
	}

	_width = 0;
	_height = 0;
}

int Plane::getHeight() {
	return _height;
}

int Plane::getWidth() {
	return _width;
}

void Plane::render(int x, int y) {
	SDL_Rect rect = { x, y, _width, _height };
  SDL_RenderCopy(_renderer, _texture, nullptr, &rect);
}
