#include "../../include/io/IOManager.h"
#include "../../include/io/Sensors/range/RangeSensor.h"
#include <iostream>

// Destructor for cleaning up the sensors if needed
IOManager::~IOManager() {
    shutdown();
}


void IOManager::initialize(){

    //registring the range sensor 
    registerSensor(SensorTypes::Range, new RangeSensor());

}

void IOManager::processInputs() {
    try {
        std::string sensorData = readSensorData(SensorTypes::Range);
        std::cout << "Sensor Data: \n" << sensorData << std::endl;
    }
    catch (const std::runtime_error& e) {
        std::cerr << "Error processing inputs: " << e.what() << std::endl;
    }
}


void IOManager::shutdown() {
    for (auto& sensor : sensors) {
        delete sensor.second; // delete sensor objects
    }
    sensors.clear();
    std::cout << "All sensors have been properly shutdown and deleted." << std::endl;
}

// Registers a sensor with the IO manager
void IOManager::registerSensor(SensorTypes sensorType, ISensor* sensor) {
    if (sensors.find(sensorType) != sensors.end()) { // if sensor is already registered
        throw std::runtime_error("Sensor type already registered."); 
        return;
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

