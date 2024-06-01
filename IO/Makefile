# Compiler
CC=g++

# Flags
CFLAGS=-I. -fPIC

# Target
TARGET=libio.so

# Source files
SRC=$(wildcard *.cpp)

# Object files
OBJ=$(SRC:.cpp=.o)

# Build rules
all: $(TARGET)

$(TARGET): $(OBJ)
	$(CC) $(CFLAGS) -shared -o $@ $^

%.o: %.cpp
	$(CC) $(CFLAGS) -c $< -o $@

clean:
	rm -f $(OBJ) $(TARGET)
