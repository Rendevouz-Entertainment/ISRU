/* Copyright 2024 Verox
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace ISRU.Unity.Runtime
{
    /// <summary>
    /// This is an example Unity script that will also be compiled with your plugin. You can add scripts like
    /// this for example to create custom controls that you will then be able to use in both the editor and
    /// in the game.
    /// </summary>
    public class ExampleScript
    {
        /// <summary>
        /// Returns a greeting for the player based on the current time of day.
        /// </summary>
        /// <param name="playerName">The name of the player.</param>
        /// <param name="isAfternoon">Whether it is currently afternoon.</param>
        /// <returns></returns>
        public static string GetGreeting(string playerName, bool isAfternoon)
        {
            return $"Good {(isAfternoon ? "afternoon" : "morning")}, {playerName}!";
        }
    }
}
