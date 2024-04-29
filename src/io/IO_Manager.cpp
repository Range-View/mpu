#include "../../include/io/IOManager.h"

// Destructor for cleaning up the sensors if needed
IOManager::~IOManager() {

}

// Registers a sensor with the IO manager
void IOManager::registerSensor(SensorTypes sensorType, ISensor* sensor) {
    if (sensors.find(sensorType) != sensors.end()) {
        // if sensor is already registered
        throw std::runtime_error("Sensor type already registered.");
    }
    sensors[sensorType] = sensor;
}

// Read data from a specific sensor
std::string IOManager::readSensorData(SensorTypes sensorType) {
    auto it = sensors.find(sensorType);
    if (it != sensors.end()) {
        return it->second->readData();
    }
    throw std::runtime_error("Sensor not found.");
}

// Write data to a specific sensor
void IOManager::writeSensorData(SensorTypes sensorType, const std::string& data) {
    auto it = sensors.find(sensorType);
    if (it != sensors.end()) {
        it->second->writeData(data);
    }
    else {
        throw std::runtime_error("Sensor not found.");
    }
}

//void IOManager::unregisterSensor(SensorTypes sensorType) {
//    auto it = sensors.find(sensorType);
//    if (it != sensors.end()) {
//        sensors.erase(it);
//    }
//    else {
//        throw std::runtime_error("Sensor not found, cannot unregister.");
//    }
//}

