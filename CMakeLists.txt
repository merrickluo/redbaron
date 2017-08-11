project("The Red Baron")

include_directories(/usr/include/SDL2)
add_executable(redbaron src/window.cc)
target_link_libraries(redbaron SDL2)
