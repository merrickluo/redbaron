#include <SDL.h>
#include "plane.h"

//Screen dimension constants
const int SCREEN_WIDTH = 1280;
const int SCREEN_HEIGHT = 960;

SDL_Window* create_window() {
	if (SDL_Init(SDL_INIT_VIDEO) < 0) {
		printf("SDL could not initialze, SDL_Error: %s\n", SDL_GetError());
		return NULL;
	}

	auto window = SDL_CreateWindow("The Red Baron",
														SDL_WINDOWPOS_UNDEFINED,
														SDL_WINDOWPOS_UNDEFINED,
														SCREEN_WIDTH,
														SCREEN_HEIGHT,
														SDL_WINDOW_SHOWN);
	if (window == NULL) {
		printf("Cannot create window, SDL_Error: %s\n", SDL_GetError());
		return NULL;
	}
	return window;
}

int main(int argc, char * args[]) {
	auto window = create_window();
	auto renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_ACCELERATED);

	try {
		// Initialize renderer color
		// auto screen_rect = { 0, 0, SCREEN_WIDTH, SCREEN_HEIGHT };
		SDL_SetRenderDrawColor(renderer, 0xFF, 0xFF, 0xFF, 0xFF);
		auto plane = new Plane(renderer, "Bipolar", 4);

		SDL_Event e;
		bool quit = false;

		while (!quit) {
			while (SDL_PollEvent(&e)) {
				if (e.type == SDL_QUIT) {
					quit = true;
				}
			}

			SDL_RenderClear(renderer);
			plane->render(300, 200);
			SDL_RenderPresent(renderer);
		}

		free(plane);
		SDL_DestroyRenderer(renderer);
    SDL_DestroyWindow(window);
	} catch (char * err) {
		printf("%s\n", err);
		return -1;
	}

	return 0;
}
