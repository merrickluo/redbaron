project("The Red Baron")

include_directories(/usr/include/SDL2)
add_executable(redbaron
	src/plane.cc
	src/main.cc)
target_link_libraries(redbaron SDL2 SDL2_image)
