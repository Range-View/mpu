#include <vector>
#include <iostream>
#include <cmath>

class DepthMatrix {
private:
    std::vector<std::vector<float>> matrix;
    size_t rows, cols;

public:
    // Initialize matrix size and allocate memory
    DepthMatrix(size_t rows, size_t cols) : rows(rows), cols(cols) {
        matrix.resize(rows, std::vector<float>(cols, 0));
    }

    void setValue(size_t row, size_t col, float value) {
        if (row < rows && col < cols) {
            matrix[row][col] = value;
        }
    }

    float getValue(size_t row, size_t col) const {
        if (row < rows && col < cols) {
            return matrix[row][col];
        }
        return -1; // Out of bounds
    }

    // Populate the matrix with ball shapes
    void populateWithDummyData(bool twoBalls = false) {
        size_t centerX1 = cols / 4;
        size_t centerY1 = rows / 2;
        size_t centerX2 = (3 * cols) / 4;
        size_t centerY2 = rows / 2;
        float radius = std::min(rows, cols) / 8.0;

        // Function to draw a circle
        auto drawCircle = [&](size_t centerX, size_t centerY, float depth) {
            for (size_t y = 0; y < rows; ++y) {
                for (size_t x = 0; x < cols; ++x) {
                    float distance = std::sqrt(std::pow(x - centerX, 2) + std::pow(y - centerY, 2));
                    if (distance <= radius) {
                        setValue(y, x, depth);
                    }
                }
            }
            };

        // Clear the matrix
        for (auto& row : matrix) {
            std::fill(row.begin(), row.end(), 0);
        }

        // Draw the circles
        drawCircle(centerX1, centerY1, 1); // First ball
        if (twoBalls) {
            drawCircle(centerX2, centerY2, 0.5); // Second ball with different depth
        }
    }

    // Convert the matrix to string (for debugging)
    std::string toString() const {
        std::string data;
        for (const auto& row : matrix) {
            for (float val : row) {
                data += std::to_string(val) + " ";
            }
            data += "\n";
        }
        return data;
    }

    // Convert the matrix to string with a visual representation (for debugging)
    std::string toClusterString() const {
        std::string data;
        const std::vector<char> intensityChars = { '.', ':', '-', '=', '+', '*', '#', '@' };
        const size_t numChars = intensityChars.size();

        for (const auto& row : matrix) {
            for (float val : row) {
                size_t index = static_cast<size_t>(val * (numChars - 1));
                if (index >= numChars) index = numChars - 1;
                data += intensityChars[index];
                data += ' ';
            }
            data += "\n";
        }
        return data;
    }

    size_t getRows() const {
        return rows;
    }

    size_t getCols() const {
        return cols;
    }
};
